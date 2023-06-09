using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBproviderUtility;
using SharedHelper.Interface;
using SharedHelper;

namespace Test
{
    public class TestService : DBOHelper
    {
        public TestService()
        {
            var _provider = (ITestProvider)CreateProvider("Test", "Test", "TestProvider", out IDBTransaction db_trans);
            //var dbOperator = ExecuteOperator(_provider);
            var dbo = ExecuteOperator<param_pms_state>(_provider);
            try
            {
                var a = dbo.Get(new param_pms_state()
                {
                    param_pms_state_cd = "T"
                });

                IEnumerable<param_pms_state> b = a.Where(x => x.param_pms_seq == 1);
                List<param_pms_state> c = b.ToList();

                db_trans.Commit();
            }
            catch(Exception ex)
            {
                db_trans.Rollback();
            }
        }
    }
}
