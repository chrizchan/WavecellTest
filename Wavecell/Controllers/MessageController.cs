using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using Wavecell.Configuration;
using Wavecell.Models;

namespace Wavecell.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {

        [HttpGet]
        public ActionResult Send()
        {
            var model = new MessageViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Send(MessageViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var destination = model.Destination.Trim();
                    var scheduleDate = SettingManager.ScheduleDateTime;
                    var account = SettingManager.Account;
                    var subAccount = SettingManager.SubAccount;
                    var password = SettingManager.AccountPassword;
                    var encoding = SettingManager.Encoding;
                    var umid = SettingManager.UMID;

                    if (destination.Substring(0, 1) != "+" && !destination.Substring(0, 1).All(Char.IsDigit))
                    {
                        ModelState.AddModelError("", "Invalid Destination");
                        return View(model);
                    }
                    if (!IsAllDigits(destination))
                    {
                        ModelState.AddModelError("", "Destination shoul be numeric");
                        return View(model);
                    }


                    destination = new String(destination.Where(c => char.IsDigit(c)).ToArray());

                    if (model.Date != null)
                    {
                        scheduleDate = String.Format("{0:G}", model.Date);
                    }
                    var sm = new WavecellSND.SendSoapClient("SendSoap");
                    var response = sm.SendMT(account, subAccount, password, umid, destination, model.Source, model.Body, encoding, scheduleDate);
                    var newUMID = response.Substring(response.LastIndexOf(':') + 1);
                   

                    var deliveryUrl = string.Format("http://wms1.wavecell.com/getDLRApi.asmx/SMSDLR?AccountId={0}&SubAccountId={1}&Password={2}&UMID={3}", account, subAccount, password, newUMID);
                    var status = getServiceResult(deliveryUrl);


                    if (!string.IsNullOrEmpty(status))
                    {
                        if (status == "TRASHED")
                        {
                            ModelState.AddModelError("", "Mesage status : TRASHED - No routing available or insufficient credit");
                        }
                        else
                        {
                            model.SavedSuccessfully = true;
                            model.Status = status;
                        }
                        return View(model);
                    }
                    else
                    {
                        model.SavedSuccessfully = true;
                        model.Status = "Message will be sent on " + model.Date;
                        return View(model);
                    }
                }
                return View(model);
            }
            catch (Exception)
            {

                return RedirectToAction("InternalServerError", "Error");
            }
            
        }

        //test for URL Callback
        //No response from wavecell API
        [AllowAnonymous]
        public string GetStatus(string Status, string Source)
        {

            var filename = AppDomain.CurrentDomain.BaseDirectory + "log\\" + "logErrors.txt";

            var sw = new System.IO.StreamWriter(filename, true);
            sw.WriteLine(DateTime.Now.ToString() + " " + Status + " " + "test 123");
            sw.Close();

            return "Success";

        }


        #region methods / function
        public string getServiceResult(string serviceUrl)
        {
            HttpWebRequest HttpWReq;
            HttpWebResponse HttpWResp;
            HttpWReq = (HttpWebRequest)WebRequest.Create(serviceUrl);
            HttpWReq.Method = "GET";
            HttpWResp = (HttpWebResponse)HttpWReq.GetResponse();
            if (HttpWResp.StatusCode == HttpStatusCode.OK)
            {
                //Consume webservice with basic XML reading, assumes it returns (one) string
                XmlReader reader = XmlReader.Create(HttpWResp.GetResponseStream());
                while (reader.Read())
                {
                    reader.MoveToFirstAttribute();
                    if (reader.NodeType == XmlNodeType.Text)
                    {
                        return reader.Value;
                    }
                }
                return String.Empty;
            }
            else
            {
                throw new Exception("Error on remote IP to Country service: " + HttpWResp.StatusCode.ToString());
            }
        }

        bool IsAllDigits(string s)
        {
            return s.Substring(1, s.Length - 1).All(Char.IsDigit);
        }

        #endregion
    }
}
