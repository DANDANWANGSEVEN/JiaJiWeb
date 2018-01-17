using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWebModel;
using JiaJiNewWebIDAL;
using JiaJiNewWeb.DALFactory;

namespace JiaJiNewWebBLL
{
    public class SuccessFulBLL
    {
        ISuccessFulDAL dal = Factory<ISuccessFulDAL>.Create("SuccessFulDAL");
        /// <summary>
        /// 获取成功案列详细信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public SuccessInfor SuccessfulShow(int Id)
        {
            return dal.SuccessfulShow(Id);
        }
        ///<summary>
        ///上一个成功案列
        ///<para>Id:成功案列Id</para>
        /// </summary>
        public SuccessInfor SuccessPrev(int Id)
        {
            try
            {
                return dal.SuccessPrev(Id);
            }
            catch(Exception ex)
            {
                return null;
            }
           
        }
        ///<summary>
        ///下一个成功案列
        ///<para>Id:成功案列Id</para>
        /// </summary>
        public SuccessInfor SuccessNext(int Id)
        {
            try
            {
                return dal.SuccessNext(Id);
            }
            catch(Exception ex)
            {
                return null;
            }
           
        }
    }
}
