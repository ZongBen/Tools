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
            //var _provider = (ITestProvider)CreateProvider("Test", "TestProvider");
            //var _provider = (ITestProvider)CreateProvider("Test", "TestProvider", out IDBTransaction db_trans);
            var dbOperator = ExecuteOperator("Test", "TestProvider", out IDBTransaction db_trans);
            try
            {
                /*
                dbOperator.Insert(new param_pms_state()
                {
                    param_pms_state_cd = "T",
                    param_pms_state_name = "測試",
                    param_pms_state_sort = 100
                });
                */

                var a = dbOperator.GetByKey(new param_pms_state
                {
                    param_pms_state_cd = "T"
                });

                dbOperator.Update(a, x =>
                {
                    x.param_pms_state_name = "測試2";
                    x.param_pms_state_sort = null;
                });

                dbOperator.Delete(a.Model);

                db_trans.Commit();
            }
            catch(Exception ex)
            {
                db_trans.RollBack();
            }
        }
    }
}
