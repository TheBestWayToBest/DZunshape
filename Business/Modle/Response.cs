using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Business.Modle
{
  public  class Response 
    {
      /// <summary>
      /// 消息响应
      /// </summary>
      public Response()
      {

      }
     private string Defaultinfo ="";
      /// <summary>
      /// 
      /// </summary>
      /// <param name="defaultInfo">默认信息</param>
      public Response( string defaultMsgText)
      {
          Defaultinfo = defaultMsgText;
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
        /// 错误类型
        /// </summary>
        [Description("错误代码")]
        public ErrorCode ErrorCode { get; set; }

       
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

                    defaultresponse.MessageText += "默认错误";
                }
                else
                {
                    defaultresponse.MessageText += Defaultinfo;
                }
                defaultresponse.IsSuccess = false;
                defaultresponse.ResultObject = null;
                return defaultresponse;
            }

        }
    }

 
  public class Response<T> : Response
  {
      /// <summary>
      /// 操作结果的泛型类，允许带一个用户自定义的泛型对象，推荐使用这个类
      /// </summary>
      /// <typeparam name="T">泛型类</typeparam>// 
      public Response()
          : base()
      {

      }
      public Response(string defaultMsgText)
          : base( defaultMsgText)
      {

      }
    
      /// <summary>
      /// 自定义的泛型数据类型
      /// </summary>
      public T Content { get; set; }
  }
    /// <summary>
    /// 错误信息
    /// </summary>
  public enum ErrorCode
  {
      /// <summary>
      /// 数据库连接失败
      /// </summary>
      DbConnectionFail,//
      /// <summary>
      /// 数据更新失败
      /// </summary>
      DbUpdateFailed ,//
      /// <summary>
      /// 数据更新行数为0
      /// </summary>
      DbChangedRowsOfZero,//

  }
}