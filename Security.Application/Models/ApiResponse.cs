using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Application.Models
{
    public class ApiResponse<T>
    {
        public T Response { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Message { get; set; }
        public int Status { get; set; }

    }
  
}
