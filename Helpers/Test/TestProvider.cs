using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenLai.SqlUtility;
using DBproviderUtility;

namespace Test
{
    public class TestProvider : SqlHelper, ITestProvider
    {
        public TestProvider(bool ExecuteTrans) : base("Data Source=BENLAI\\SQLEXPRESS;Initial Catalog=PeaHie;Integrated Security=true", ExecuteTrans) { }

        public IList<param_pms_state> Get()
        {
            StringBuilder SbSql = new StringBuilder();
            SbSql.Append("SELECT" + Environment.NewLine);
            SbSql.Append("	*" + Environment.NewLine);
            SbSql.Append("FROM param_pms_state" + Environment.NewLine);
            return ExecuteList<param_pms_state>(SbSql.ToString(), new SqlHelperParameters());
        }

        public int Insert(param_pms_state model)
        {
            StringBuilder SbSql = new StringBuilder();
            SqlHelperParameters parameters = new SqlHelperParameters();
            SbSql.Append("INSERT INTO param_pms_state" + Environment.NewLine);
            SbSql.Append("(" + Environment.NewLine);
            SbSql.Append("param_pms_state_cd" + Environment.NewLine);
            SbSql.Append(",param_pms_state_name" + Environment.NewLine);
            SbSql.Append(",param_pms_state_sort" + Environment.NewLine);
            SbSql.Append(")" + Environment.NewLine);
            SbSql.Append("VALUES" + Environment.NewLine);
            SbSql.Append("(" + Environment.NewLine);
            SbSql.Append("@param_pms_state_cd" + Environment.NewLine);
            SbSql.Append(",@param_pms_state_name" + Environment.NewLine);
            SbSql.Append(",@param_pms_state_sort" + Environment.NewLine);
            SbSql.Append(")" + Environment.NewLine);
            parameters.Add("@param_pms_state_cd", model.param_pms_state_cd);
            parameters.Add("@param_pms_state_name", model.param_pms_state_name);
            parameters.Add("@param_pms_state_sort", model.param_pms_state_sort);
            return ExecuteNonQuery(SbSql.ToString(), parameters);
        }
    }
}
