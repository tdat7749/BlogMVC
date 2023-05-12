using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.ViewModel.Common
{
    public class JsonResponseData<T> : JsonResponse
    {
        public T Data { get; set; }
    }
}
