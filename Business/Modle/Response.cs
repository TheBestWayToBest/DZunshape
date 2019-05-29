using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Business.Modle
{
  public  class Response
    {
      public Response()
      {

      }
      string Defaultinfo ="";
      /// <summary>
      /// 
      /// </summary>
      /// <param name="defaultInfo">默认信息</param>
      public Response( string defaultInfo)
      {
          Defaultinfo = defaultInfo;
      }
      /// <summary>
      /// 是否成功
      /// </summary>
        [CategoryAttribute("系统"), Description("是否成功？")]
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 消息文本
        /// </summary>
        [Description("消息文本")]
        public string MessageText { get; set; }
 

        /// <summary>
        /// 结果对象
        /// </summary>
        [Description("结果对象")]
        public object ResultObject { get; set; }

      /// <summary>
      /// 默认信息 返回默认是false
      /// </summary>
        [Description("默认信息")]
        public Response DefaultResponse
        {
            get
            {
                Response defaultresponse = new Response();
                if (string.IsNullOrWhiteSpace(Defaultinfo))
                {

                    defaultresponse.MessageText = "默认错误";
                }
                else
                {
                    defaultresponse.MessageText = Defaultinfo;
                }
                defaultresponse.IsSuccess = false;
                defaultresponse.ResultObject = null;
                return defaultresponse;
            }

        }
    }
}
