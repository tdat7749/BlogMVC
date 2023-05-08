using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.ViewModel.Common
{
    public class PagingResponse<T>
    {
        public int TotalPage { get; set; }
        public int TotalRecord { get; set; }
        public T Data { get; set; }

        public PagingResponse()
        {

        }

        public PagingResponse(int totalPage, int totalRecord, T data)
        {
            TotalPage = totalPage;
            TotalRecord = totalRecord;
            Data = data;
        }
    }
}
