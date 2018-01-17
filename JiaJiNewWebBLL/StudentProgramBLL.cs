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
    public class StudentProgramBLL
    {
        IStudentProgramDAL dal = Factory<IStudentProgramDAL>.Create("StudentProgramDAL");
        ///<summary>
        ///规划详情
        ///<para>Id:规划ID</para>
        /// </summary>
        public StudentProgram StudentShow(int Id)
        {
            return dal.StudentShow(Id);
        }

        /// <summary>
        /// 获取具体国家规划列表
        /// </summary>
        /// <returns></returns>
        public List<StudentProgram> StudentProgramList(int pageindex)
        {
            try
            {
                return dal.StudentProgramList(pageindex);
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// 获取国家规划页数
        /// </summary>
        /// <returns></returns>
        public int GetRowCounts()
        {
            try
            {
                return dal.GetRowCounts();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        ///<summary>
        ///上一个规划
        ///<para>Id:成功案列Id</para>
        /// </summary>
        public StudentProgram StudentPrev(int Id)
        {
            return dal.StudentPrev(Id);
        }
        ///<summary>
        ///下一个规划
        ///<para>Id:成功案列Id</para>
        /// </summary>
        public StudentProgram StudentNext(int Id)
        {
            return dal.StudentNext(Id);
        }
        ///<summary>
        ///留学规划类别
        /// </summary>
        public List<StudentProgramType> TypeShow()
        {
            try
            {
                return dal.TypeShow();

            }
            catch(Exception ex)
            {
                return null;
            }
        }

        ///<summary>
        ///申请条件
        /// </summary>
        public List<ApplyContentInfo> ApplyShow(int countryid, int educationid)
        {
            try
            {
                return dal.ApplyShow(countryid, educationid);
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        ///<summary>
        ///申请时间规划表
        /// </summary>
        public List<ArrangeTime> ArrangeShow(int countryid, int educationid)
        {
            return dal.ArrangeShow(countryid, educationid);
        }
    }
}
