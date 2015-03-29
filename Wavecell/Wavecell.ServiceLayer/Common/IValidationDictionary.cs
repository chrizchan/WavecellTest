using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wavecell.ServiceLayer.Common
{
        public interface IValidationDictionary
        {
            void AddError(string key, string errorMessage);
            bool IsValid { get; }
        }
    
}
