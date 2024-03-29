


using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using SubSonic.DataProviders;
using SubSonic.Extensions;
using SubSonic.Linq.Structure;
using SubSonic.Query;
using SubSonic.Schema;
using System.Data.Common;
using System.Collections.Generic;

namespace WangxiaoCN
{
    public partial class WangxiaoCNDB : IQuerySurface
    {

        public IDataProvider DataProvider;
        public DbQueryProvider provider;
        
        public static IDataProvider DefaultDataProvider { get; set; }

        public bool TestMode
		{
            get
			{
                return DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            }
        }

        public WangxiaoCNDB() 
        {
            if (DefaultDataProvider == null) {
                DataProvider = ProviderFactory.GetProvider("WangxiaoCN");
            }
            else {
                DataProvider = DefaultDataProvider;
            }
            Init();
        }

        public WangxiaoCNDB(string connectionStringName)
        {
            DataProvider = ProviderFactory.GetProvider(connectionStringName);
            Init();
        }

		public WangxiaoCNDB(string connectionString, string providerName)
        {
            DataProvider = ProviderFactory.GetProvider(connectionString,providerName);
            Init();
        }

		public ITable FindByPrimaryKey(string pkName)
        {
            return DataProvider.Schema.Tables.SingleOrDefault(x => x.PrimaryKey.Name.Equals(pkName, StringComparison.InvariantCultureIgnoreCase));
        }

        public Query<T> GetQuery<T>()
        {
            return new Query<T>(provider);
        }
        
        public ITable FindTable(string tableName)
        {
            return DataProvider.FindTable(tableName);
        }
               
        public IDataProvider Provider
        {
            get { return DataProvider; }
            set {DataProvider=value;}
        }
        
        public DbQueryProvider QueryProvider
        {
            get { return provider; }
        }
        
        BatchQuery _batch = null;
        public void Queue<T>(IQueryable<T> qry)
        {
            if (_batch == null)
                _batch = new BatchQuery(Provider, QueryProvider);
            _batch.Queue(qry);
        }

        public void Queue(ISqlQuery qry)
        {
            if (_batch == null)
                _batch = new BatchQuery(Provider, QueryProvider);
            _batch.Queue(qry);
        }

        public void ExecuteTransaction(IList<DbCommand> commands)
		{
            if(!TestMode)
			{
                using(var connection = commands[0].Connection)
				{
                   if (connection.State == ConnectionState.Closed)
                        connection.Open();
                   
                   using (var trans = connection.BeginTransaction()) 
				   {
                        foreach (var cmd in commands) 
						{
                            cmd.Transaction = trans;
                            cmd.Connection = connection;
                            cmd.ExecuteNonQuery();
                        }
                        trans.Commit();
                    }
                    connection.Close();
                }
            }
        }

        public IDataReader ExecuteBatch()
        {
            if (_batch == null)
                throw new InvalidOperationException("There's nothing in the queue");
            if(!TestMode)
                return _batch.ExecuteReader();
            return null;
        }
			
        public Query<WXSysProvince> WXSysProvinces { get; set; }
        public Query<WXSysCity> WXSysCities { get; set; }
        public Query<WXAdminPowerCategory> WXAdminPowerCategories { get; set; }
        public Query<WXAdminUser> WXAdminUsers { get; set; }
        public Query<WXPointsBank> WXPointsBanks { get; set; }
        public Query<WXUser> WXUsers { get; set; }
        public Query<WXSysExamCategory> WXSysExamCategories { get; set; }
        public Query<WXExamDetail> WXExamDetails { get; set; }
        public Query<WXSysYear> WXSysYears { get; set; }
        public Query<WXSysExamQstType> WXSysExamQstTypes { get; set; }
        public Query<WXSysExamType> WXSysExamTypes { get; set; }
        public Query<WXExamPaper> WXExamPapers { get; set; }
        public Query<WXAdmin_Logs_Opration> WXAdmin_Logs_Oprations { get; set; }
        public Query<WXAdmin_Power_Tree> WXAdmin_Power_Trees { get; set; }
        public Query<WXUserDetail> WXUserDetails { get; set; }

			

        #region ' Aggregates and SubSonic Queries '
        public Select SelectColumns(params string[] columns)
        {
            return new Select(DataProvider, columns);
        }

        public Select Select
        {
            get { return new Select(this.Provider); }
        }

        public Insert Insert
		{
            get { return new Insert(this.Provider); }
        }

        public Update<T> Update<T>() where T:new()
		{
            return new Update<T>(this.Provider);
        }

        public SqlQuery Delete<T>(Expression<Func<T,bool>> column) where T:new()
        {
            LambdaExpression lamda = column;
            SqlQuery result = new Delete<T>(this.Provider);
            result = result.From<T>();
            result.Constraints=lamda.ParseConstraints().ToList();
            return result;
        }

        public SqlQuery Max<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = DataProvider.FindTable(objectName).Name;
            return new Select(DataProvider, new Aggregate(colName, AggregateFunction.Max)).From(tableName);
        }

        public SqlQuery Min<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.Min)).From(tableName);
        }

        public SqlQuery Sum<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.Sum)).From(tableName);
        }

        public SqlQuery Avg<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.Avg)).From(tableName);
        }

        public SqlQuery Count<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.Count)).From(tableName);
        }

        public SqlQuery Variance<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.Var)).From(tableName);
        }

        public SqlQuery StandardDeviation<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.StDev)).From(tableName);
        }

        #endregion

        void Init()
        {
            provider = new DbQueryProvider(this.Provider);

            #region ' Query Defs '
            WXSysProvinces = new Query<WXSysProvince>(provider);
            WXSysCities = new Query<WXSysCity>(provider);
            WXAdminPowerCategories = new Query<WXAdminPowerCategory>(provider);
            WXAdminUsers = new Query<WXAdminUser>(provider);
            WXPointsBanks = new Query<WXPointsBank>(provider);
            WXUsers = new Query<WXUser>(provider);
            WXSysExamCategories = new Query<WXSysExamCategory>(provider);
            WXExamDetails = new Query<WXExamDetail>(provider);
            WXSysYears = new Query<WXSysYear>(provider);
            WXSysExamQstTypes = new Query<WXSysExamQstType>(provider);
            WXSysExamTypes = new Query<WXSysExamType>(provider);
            WXExamPapers = new Query<WXExamPaper>(provider);
            WXAdmin_Logs_Oprations = new Query<WXAdmin_Logs_Opration>(provider);
            WXAdmin_Power_Trees = new Query<WXAdmin_Power_Tree>(provider);
            WXUserDetails = new Query<WXUserDetail>(provider);
            #endregion


            #region ' Schemas '
        	if(DataProvider.Schema.Tables.Count == 0)
			{
            	DataProvider.Schema.Tables.Add(new WXSysProvinceTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new WXSysCityTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new WXAdminPowerCategoryTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new WXAdminUsersTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new WXPointsBankTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new WXUsersTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new WXSysExamCategoryTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new WXExamDetailTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new WXSysYearsTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new WXSysExamQstTypeTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new WXSysExamTypeTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new WXExamPaperTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new WXAdmin_Logs_OprationTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new WXAdmin_Power_TreeTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new WXUserDetailsTable(DataProvider));
            }
            #endregion
        }
        

        #region ' Helpers '
            
        internal static DateTime DateTimeNowTruncatedDownToSecond() {
            var now = DateTime.Now;
            return now.AddTicks(-now.Ticks % TimeSpan.TicksPerSecond);
        }

        #endregion

    }
}