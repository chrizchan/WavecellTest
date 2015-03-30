using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security;
using System.Text;
using System.Security.Principal;
using System.Web.Security;

namespace Wavecell.Security
{
    //[Serializable]
    public class UserIdentity : GenericIdentity //IIdentity,  ISerializable
    {
        private int _userId;

        public UserIdentity(int userId, string name)
            : base(name)
        {
            _userId = userId;
        }

        public int UserId { get { return _userId; } }

        //private int _userId;
        //private string _userName;

        //public UserIdentity(int userId, string name)
        //{
        //    _userId = userId;
        //    _userName = name;
        //}

        //public string Name
        //{
        //    get { return _userName; }
        //}

        //public int UserId { get { return _userId; } }

        //public string AuthenticationType
        //{
        //    get { return "User"; }
        //}

        //public bool IsAuthenticated
        //{
        //    get { return true; }
        //}
        //[SecurityCritical]
        //public void GetObjectData(SerializationInfo info, StreamingContext context)
        //{
        //    if (context.State != StreamingContextStates.CrossAppDomain)
        //    {
        //        throw new InvalidOperationException("Serialization not supported");
        //    }

        //    var gIdent = new GenericIdentity(Name, AuthenticationType);
        //    info.SetType(gIdent.GetType());

        //    var serializableMembers = FormatterServices.GetSerializableMembers(gIdent.GetType());
        //    var serializableValues = FormatterServices.GetObjectData(gIdent, serializableMembers);

        //    for (var i = 0; i < serializableMembers.Length; i++)
        //    {
        //        info.AddValue(serializableMembers[i].Name, serializableValues[i]);
        //    }
        //}
    }
}
