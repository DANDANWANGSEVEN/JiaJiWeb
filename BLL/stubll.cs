using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiDAL;
namespace JiaJiBLL
{
  public  class stubll
    {
        studentdal dal = new studentdal();
        public int Stuadd(JiaJiModels.student stu)
        {
            return dal.stuadd(stu);
        }

        /// <summary>
        /// 学历添加
        /// </summary>
        /// <param name="ename"></param>
        /// <returns></returns>
        public int EaucationAdd(string ename)
        {
            return dal.EaucationAdd(ename);
        }
        /// <summary>
        /// 获取学历列表信息
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.educationtype> Edushow()
        {
            return dal.Edushow();
        }
        /// <summary>
        /// 获取团队列表信息
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.Team> Tshow()
        {
            return dal.Tshow();
        }


        #region  学生信息

        /// <summary>
        /// 获取学生列表信息
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.student> stushow()
        {
            try
            {
                return dal.stushow();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 删除学生信息
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelStudent(string StudentID)
        {
            try
            {
                return dal.DelStudent(StudentID);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 添加xuesheng信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int addStu(JiaJiModels.student model)
        {
            try
            {
                return new JiaJiDAL.studentdal().addStu(model);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        /// <summary>
        /// 修改学生信息
        /// </summary>
        /// <returns></returns>
        public int UpdateStu(JiaJiModels.student model)
        {
            try
            {
                return new JiaJiDAL.studentdal().UpdateStu(model);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        #endregion


        #region 国家页面留学规划
        /// <summary>
        /// 获取国家页面留学规划
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.studentprogramtype> showcounguihua()
        {
            try
            {
                return new JiaJiDAL.studentdal().showcounguihua();
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        /// <summary>
        /// 删除国家页面留学规划
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool Delcounguihua(string TypeID)
        {
            try
            {

                return new JiaJiDAL.studentdal().Delcounguihua(TypeID);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 添加国家页面留学规划
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int addcounguihua(JiaJiModels.studentprogramtype model)
        {
            try
            {

                return new JiaJiDAL.studentdal().addcounguihua(model);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        /// <summary>
        /// 修改国家页面留学规划
        /// </summary>
        /// <returns></returns>
        public int Updatecounguihua(JiaJiModels.studentprogramtype model)
        {
            try
            {
                return new JiaJiDAL.studentdal().Updatecounguihua(model);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }





        #endregion


    }
}
