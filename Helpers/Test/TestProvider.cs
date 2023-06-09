using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenLai.SqlUtility;
using DBproviderUtility;
using SharedHelper.Interface;

namespace Test
{
    public class TestProvider : SqlHelper, ITestProvider, IDBOperator<param_pms_state>
    {
        public TestProvider(bool ExecuteTrans) : base("Data Source=EKERA-PG7;Initial Catalog=PMS_TEST;Integrated Security=true", ExecuteTrans) { }

        public IList<param_pms_state> Get(param_pms_state model)
        {
            StringBuilder SbSql = new StringBuilder();
            SqlHelperParameters parameters = new SqlHelperParameters();
            SbSql.Append("SELECT" + Environment.NewLine);
            SbSql.Append("	*" + Environment.NewLine);
            SbSql.Append("FROM param_pms_state" + Environment.NewLine);
            SbSql.Append("WHERE 1=1" + Environment.NewLine);
            if (!string.IsNullOrEmpty(model.param_pms_state_cd))
            {
                SbSql.Append("AND param_pms_state_cd = @param_pms_state_cd" + Environment.NewLine);
                parameters.Add("@param_pms_state_cd", model.param_pms_state_cd);
            }
            return ExecuteList<param_pms_state>(SbSql.ToString(), parameters);
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

        public int Update(param_pms_state Model)
        {
            throw new NotImplementedException();
        }

        public int Delete(param_pms_state Model)
        {
            throw new NotImplementedException();
        }
    }
}
