using JiaJiNewWebModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiNewWebIDAL
{
    public interface ISuccessFulDAL
    {
        ///<summary>
        ///获取成功案列详情
        ///<para>Id:案列ID</para>
        /// </summary>
        SuccessInfor SuccessfulShow(int Id);
        ///<summary>
        ///上一个成功案列
        ///<para>Id:成功案列Id</para>
        /// </summary>
        SuccessInfor SuccessPrev(int Id);
        ///<summary>
        ///下一个成功案列
        ///<para>Id:成功案列Id</para>
        /// </summary>
        SuccessInfor SuccessNext(int Id);
    }
}
