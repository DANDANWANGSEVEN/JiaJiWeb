using JiaJiNewWebModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiNewWebIDAL
{
    public interface IStudentProgramDAL
    {
        ///<summary>
        ///规划详情
        ///<para>Id:规划ID</para>
        /// </summary>
        StudentProgram StudentShow(int Id);


        /// <summary>
        /// 获取具体国家规划列表
        /// </summary>
        /// <returns></returns>
        List<StudentProgram> StudentProgramList(int pageindex);

        /// <summary>
        /// 获取国家规划页数
        /// </summary>
        /// <returns></returns>
        int GetRowCounts();

        ///<summary>
        ///上一个规划
        ///<para>Id:成功案列Id</para>
        /// </summary>
        StudentProgram StudentPrev(int Id);

        ///<summary>
        ///下一个规划
        ///<para>Id:成功案列Id</para>
        /// </summary>
        StudentProgram StudentNext(int Id);
        ///<summary>
        ///留学规划类别
        /// </summary>
        List<StudentProgramType> TypeShow();

        ///<summary>
        ///申请条件
        /// </summary>
        List<ApplyContentInfo> ApplyShow(int countryid, int educationid);

        ///<summary>
        ///申请时间规划表
        /// </summary>
        List<ArrangeTime> ArrangeShow(int countryid, int educationid);
    }
}
