using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.HandleResponses
{
    public class ValidationErrorResponse : CustomExeption
    {
        public ValidationErrorResponse() 
            : base(400)
        {
        }
        public IEnumerable<string> Errors { get; set; }
    }
}
