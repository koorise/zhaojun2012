


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SubSonic.DataProviders;
using SubSonic.Extensions;
using System.Linq.Expressions;
using SubSonic.Schema;
using System.Collections;
using SubSonic;
using SubSonic.Repository;
using System.ComponentModel;
using System.Data.Common;

namespace WangxiaoCN
{
    
    
    /// <summary>
    /// A class which represents the vw_ExamPaper_ExamCategory table in the WangxiaoCN Database.
    /// </summary>
    public partial class vwExamPaperExamCategory: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<vwExamPaperExamCategory> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<vwExamPaperExamCategory>(new WangxiaoCN.WangxiaoCNDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<vwExamPaperExamCategory> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(vwExamPaperExamCategory item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                vwExamPaperExamCategory item=new vwExamPaperExamCategory();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<vwExamPaperExamCategory> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        WangxiaoCN.WangxiaoCNDB _db;
        public vwExamPaperExamCategory(string connectionString, string providerName) {

            _db=new WangxiaoCN.WangxiaoCNDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                vwExamPaperExamCategory.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<vwExamPaperExamCategory>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public vwExamPaperExamCategory(){
             _db=new WangxiaoCN.WangxiaoCNDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public vwExamPaperExamCategory(Expression<Func<vwExamPaperExamCategory, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<vwExamPaperExamCategory> GetRepo(string connectionString, string providerName){
            WangxiaoCN.WangxiaoCNDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new WangxiaoCN.WangxiaoCNDB();
            }else{
                db=new WangxiaoCN.WangxiaoCNDB(connectionString, providerName);
            }
            IRepository<vwExamPaperExamCategory> _repo;
            
            if(db.TestMode){
                vwExamPaperExamCategory.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<vwExamPaperExamCategory>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<vwExamPaperExamCategory> GetRepo(){
            return GetRepo("","");
        }
        
        public static vwExamPaperExamCategory SingleOrDefault(Expression<Func<vwExamPaperExamCategory, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            vwExamPaperExamCategory single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static vwExamPaperExamCategory SingleOrDefault(Expression<Func<vwExamPaperExamCategory, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            vwExamPaperExamCategory single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<vwExamPaperExamCategory, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<vwExamPaperExamCategory, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<vwExamPaperExamCategory> Find(Expression<Func<vwExamPaperExamCategory, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<vwExamPaperExamCategory> Find(Expression<Func<vwExamPaperExamCategory, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<vwExamPaperExamCategory> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<vwExamPaperExamCategory> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<vwExamPaperExamCategory> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<vwExamPaperExamCategory> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<vwExamPaperExamCategory> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<vwExamPaperExamCategory> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "ID";
        }

        public object KeyValue()
        {
            return this.ID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.eTitle.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(vwExamPaperExamCategory)){
                vwExamPaperExamCategory compare=(vwExamPaperExamCategory)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.ID;
        }
        
        public string DescriptorValue()
        {
                            return this.eTitle.ToString();
                    }

        public string DescriptorColumn() {
            return "eTitle";
        }
        public static string GetKeyColumn()
        {
            return "ID";
        }        
        public static string GetDescriptorColumn()
        {
            return "eTitle";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _ID;
        public int ID
        {
            get { return _ID; }
            set
            {
                if(_ID!=value){
                    _ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        Guid _ExamGID;
        public Guid ExamGID
        {
            get { return _ExamGID; }
            set
            {
                if(_ExamGID!=value){
                    _ExamGID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ExamGID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        Guid _ClassGID;
        public Guid ClassGID
        {
            get { return _ClassGID; }
            set
            {
                if(_ClassGID!=value){
                    _ClassGID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ClassGID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _PvcID;
        public int PvcID
        {
            get { return _PvcID; }
            set
            {
                if(_PvcID!=value){
                    _PvcID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PvcID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _eTitle;
        public string eTitle
        {
            get { return _eTitle; }
            set
            {
                if(_eTitle!=value){
                    _eTitle=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="eTitle");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _eYear;
        public int eYear
        {
            get { return _eYear; }
            set
            {
                if(_eYear!=value){
                    _eYear=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="eYear");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _eStars;
        public int eStars
        {
            get { return _eStars; }
            set
            {
                if(_eStars!=value){
                    _eStars=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="eStars");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _eTotalScore;
        public int eTotalScore
        {
            get { return _eTotalScore; }
            set
            {
                if(_eTotalScore!=value){
                    _eTotalScore=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="eTotalScore");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _ePassingScore;
        public int ePassingScore
        {
            get { return _ePassingScore; }
            set
            {
                if(_ePassingScore!=value){
                    _ePassingScore=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ePassingScore");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _eFrom;
        public string eFrom
        {
            get { return _eFrom; }
            set
            {
                if(_eFrom!=value){
                    _eFrom=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="eFrom");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _eHot;
        public int eHot
        {
            get { return _eHot; }
            set
            {
                if(_eHot!=value){
                    _eHot=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="eHot");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _ePoints;
        public int ePoints
        {
            get { return _ePoints; }
            set
            {
                if(_ePoints!=value){
                    _ePoints=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ePoints");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _className;
        public string className
        {
            get { return _className; }
            set
            {
                if(_className!=value){
                    _className=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="className");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _path;
        public string path
        {
            get { return _path; }
            set
            {
                if(_path!=value){
                    _path=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="path");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _pName;
        public string pName
        {
            get { return _pName; }
            set
            {
                if(_pName!=value){
                    _pName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="pName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        Guid _PID;
        public Guid PID
        {
            get { return _PID; }
            set
            {
                if(_PID!=value){
                    _PID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<vwExamPaperExamCategory, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the vw_sys_Province_City table in the WangxiaoCN Database.
    /// </summary>
    public partial class vwsysProvinceCity: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<vwsysProvinceCity> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<vwsysProvinceCity>(new WangxiaoCN.WangxiaoCNDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<vwsysProvinceCity> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(vwsysProvinceCity item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                vwsysProvinceCity item=new vwsysProvinceCity();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<vwsysProvinceCity> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        WangxiaoCN.WangxiaoCNDB _db;
        public vwsysProvinceCity(string connectionString, string providerName) {

            _db=new WangxiaoCN.WangxiaoCNDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                vwsysProvinceCity.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<vwsysProvinceCity>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public vwsysProvinceCity(){
             _db=new WangxiaoCN.WangxiaoCNDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public vwsysProvinceCity(Expression<Func<vwsysProvinceCity, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<vwsysProvinceCity> GetRepo(string connectionString, string providerName){
            WangxiaoCN.WangxiaoCNDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new WangxiaoCN.WangxiaoCNDB();
            }else{
                db=new WangxiaoCN.WangxiaoCNDB(connectionString, providerName);
            }
            IRepository<vwsysProvinceCity> _repo;
            
            if(db.TestMode){
                vwsysProvinceCity.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<vwsysProvinceCity>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<vwsysProvinceCity> GetRepo(){
            return GetRepo("","");
        }
        
        public static vwsysProvinceCity SingleOrDefault(Expression<Func<vwsysProvinceCity, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            vwsysProvinceCity single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static vwsysProvinceCity SingleOrDefault(Expression<Func<vwsysProvinceCity, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            vwsysProvinceCity single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<vwsysProvinceCity, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<vwsysProvinceCity, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<vwsysProvinceCity> Find(Expression<Func<vwsysProvinceCity, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<vwsysProvinceCity> Find(Expression<Func<vwsysProvinceCity, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<vwsysProvinceCity> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<vwsysProvinceCity> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<vwsysProvinceCity> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<vwsysProvinceCity> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<vwsysProvinceCity> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<vwsysProvinceCity> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "pID";
        }

        public object KeyValue()
        {
            return this.pID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.pName.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(vwsysProvinceCity)){
                vwsysProvinceCity compare=(vwsysProvinceCity)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.pID;
        }
        
        public string DescriptorValue()
        {
                            return this.pName.ToString();
                    }

        public string DescriptorColumn() {
            return "pName";
        }
        public static string GetKeyColumn()
        {
            return "pID";
        }        
        public static string GetDescriptorColumn()
        {
            return "pName";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _pID;
        public int pID
        {
            get { return _pID; }
            set
            {
                if(_pID!=value){
                    _pID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="pID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _pName;
        public string pName
        {
            get { return _pName; }
            set
            {
                if(_pName!=value){
                    _pName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="pName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _cID;
        public int cID
        {
            get { return _cID; }
            set
            {
                if(_cID!=value){
                    _cID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="cID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _cName;
        public string cName
        {
            get { return _cName; }
            set
            {
                if(_cName!=value){
                    _cName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="cName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<vwsysProvinceCity, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the WXAdminPowerCategory table in the WangxiaoCN Database.
    /// </summary>
    public partial class WXAdminPowerCategory: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<WXAdminPowerCategory> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<WXAdminPowerCategory>(new WangxiaoCN.WangxiaoCNDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<WXAdminPowerCategory> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(WXAdminPowerCategory item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                WXAdminPowerCategory item=new WXAdminPowerCategory();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<WXAdminPowerCategory> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        WangxiaoCN.WangxiaoCNDB _db;
        public WXAdminPowerCategory(string connectionString, string providerName) {

            _db=new WangxiaoCN.WangxiaoCNDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                WXAdminPowerCategory.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<WXAdminPowerCategory>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public WXAdminPowerCategory(){
             _db=new WangxiaoCN.WangxiaoCNDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public WXAdminPowerCategory(Expression<Func<WXAdminPowerCategory, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<WXAdminPowerCategory> GetRepo(string connectionString, string providerName){
            WangxiaoCN.WangxiaoCNDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new WangxiaoCN.WangxiaoCNDB();
            }else{
                db=new WangxiaoCN.WangxiaoCNDB(connectionString, providerName);
            }
            IRepository<WXAdminPowerCategory> _repo;
            
            if(db.TestMode){
                WXAdminPowerCategory.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<WXAdminPowerCategory>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<WXAdminPowerCategory> GetRepo(){
            return GetRepo("","");
        }
        
        public static WXAdminPowerCategory SingleOrDefault(Expression<Func<WXAdminPowerCategory, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            WXAdminPowerCategory single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static WXAdminPowerCategory SingleOrDefault(Expression<Func<WXAdminPowerCategory, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            WXAdminPowerCategory single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<WXAdminPowerCategory, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<WXAdminPowerCategory, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<WXAdminPowerCategory> Find(Expression<Func<WXAdminPowerCategory, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<WXAdminPowerCategory> Find(Expression<Func<WXAdminPowerCategory, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<WXAdminPowerCategory> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<WXAdminPowerCategory> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<WXAdminPowerCategory> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<WXAdminPowerCategory> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<WXAdminPowerCategory> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<WXAdminPowerCategory> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "ID";
        }

        public object KeyValue()
        {
            return this.ID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.LevelName.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(WXAdminPowerCategory)){
                WXAdminPowerCategory compare=(WXAdminPowerCategory)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.ID;
        }
        
        public string DescriptorValue()
        {
                            return this.LevelName.ToString();
                    }

        public string DescriptorColumn() {
            return "LevelName";
        }
        public static string GetKeyColumn()
        {
            return "ID";
        }        
        public static string GetDescriptorColumn()
        {
            return "LevelName";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _ID;
        public int ID
        {
            get { return _ID; }
            set
            {
                if(_ID!=value){
                    _ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _LevelName;
        public string LevelName
        {
            get { return _LevelName; }
            set
            {
                if(_LevelName!=value){
                    _LevelName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LevelName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _LevelNum;
        public int? LevelNum
        {
            get { return _LevelNum; }
            set
            {
                if(_LevelNum!=value){
                    _LevelNum=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LevelNum");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<WXAdminPowerCategory, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the WXAdminUsers table in the WangxiaoCN Database.
    /// </summary>
    public partial class WXAdminUser: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<WXAdminUser> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<WXAdminUser>(new WangxiaoCN.WangxiaoCNDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<WXAdminUser> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(WXAdminUser item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                WXAdminUser item=new WXAdminUser();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<WXAdminUser> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        WangxiaoCN.WangxiaoCNDB _db;
        public WXAdminUser(string connectionString, string providerName) {

            _db=new WangxiaoCN.WangxiaoCNDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                WXAdminUser.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<WXAdminUser>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public WXAdminUser(){
             _db=new WangxiaoCN.WangxiaoCNDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public WXAdminUser(Expression<Func<WXAdminUser, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<WXAdminUser> GetRepo(string connectionString, string providerName){
            WangxiaoCN.WangxiaoCNDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new WangxiaoCN.WangxiaoCNDB();
            }else{
                db=new WangxiaoCN.WangxiaoCNDB(connectionString, providerName);
            }
            IRepository<WXAdminUser> _repo;
            
            if(db.TestMode){
                WXAdminUser.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<WXAdminUser>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<WXAdminUser> GetRepo(){
            return GetRepo("","");
        }
        
        public static WXAdminUser SingleOrDefault(Expression<Func<WXAdminUser, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            WXAdminUser single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static WXAdminUser SingleOrDefault(Expression<Func<WXAdminUser, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            WXAdminUser single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<WXAdminUser, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<WXAdminUser, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<WXAdminUser> Find(Expression<Func<WXAdminUser, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<WXAdminUser> Find(Expression<Func<WXAdminUser, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<WXAdminUser> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<WXAdminUser> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<WXAdminUser> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<WXAdminUser> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<WXAdminUser> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<WXAdminUser> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "ID";
        }

        public object KeyValue()
        {
            return this.ID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.AdminUserName.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(WXAdminUser)){
                WXAdminUser compare=(WXAdminUser)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.ID;
        }
        
        public string DescriptorValue()
        {
                            return this.AdminUserName.ToString();
                    }

        public string DescriptorColumn() {
            return "AdminUserName";
        }
        public static string GetKeyColumn()
        {
            return "ID";
        }        
        public static string GetDescriptorColumn()
        {
            return "AdminUserName";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _ID;
        public int ID
        {
            get { return _ID; }
            set
            {
                if(_ID!=value){
                    _ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        Guid _GID;
        public Guid GID
        {
            get { return _GID; }
            set
            {
                if(_GID!=value){
                    _GID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="GID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _AdminUserName;
        public string AdminUserName
        {
            get { return _AdminUserName; }
            set
            {
                if(_AdminUserName!=value){
                    _AdminUserName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="AdminUserName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _AdminPassWord;
        public string AdminPassWord
        {
            get { return _AdminPassWord; }
            set
            {
                if(_AdminPassWord!=value){
                    _AdminPassWord=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="AdminPassWord");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _AdminLevelID;
        public int? AdminLevelID
        {
            get { return _AdminLevelID; }
            set
            {
                if(_AdminLevelID!=value){
                    _AdminLevelID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="AdminLevelID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<WXAdminUser, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the WXExamDetail table in the WangxiaoCN Database.
    /// </summary>
    public partial class WXExamDetail: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<WXExamDetail> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<WXExamDetail>(new WangxiaoCN.WangxiaoCNDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<WXExamDetail> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(WXExamDetail item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                WXExamDetail item=new WXExamDetail();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<WXExamDetail> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        WangxiaoCN.WangxiaoCNDB _db;
        public WXExamDetail(string connectionString, string providerName) {

            _db=new WangxiaoCN.WangxiaoCNDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                WXExamDetail.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<WXExamDetail>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public WXExamDetail(){
             _db=new WangxiaoCN.WangxiaoCNDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public WXExamDetail(Expression<Func<WXExamDetail, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<WXExamDetail> GetRepo(string connectionString, string providerName){
            WangxiaoCN.WangxiaoCNDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new WangxiaoCN.WangxiaoCNDB();
            }else{
                db=new WangxiaoCN.WangxiaoCNDB(connectionString, providerName);
            }
            IRepository<WXExamDetail> _repo;
            
            if(db.TestMode){
                WXExamDetail.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<WXExamDetail>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<WXExamDetail> GetRepo(){
            return GetRepo("","");
        }
        
        public static WXExamDetail SingleOrDefault(Expression<Func<WXExamDetail, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            WXExamDetail single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static WXExamDetail SingleOrDefault(Expression<Func<WXExamDetail, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            WXExamDetail single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<WXExamDetail, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<WXExamDetail, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<WXExamDetail> Find(Expression<Func<WXExamDetail, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<WXExamDetail> Find(Expression<Func<WXExamDetail, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<WXExamDetail> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<WXExamDetail> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<WXExamDetail> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<WXExamDetail> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<WXExamDetail> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<WXExamDetail> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "ID";
        }

        public object KeyValue()
        {
            return this.ID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.qContent.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(WXExamDetail)){
                WXExamDetail compare=(WXExamDetail)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.ID;
        }
        
        public string DescriptorValue()
        {
                            return this.qContent.ToString();
                    }

        public string DescriptorColumn() {
            return "qContent";
        }
        public static string GetKeyColumn()
        {
            return "ID";
        }        
        public static string GetDescriptorColumn()
        {
            return "qContent";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _ID;
        public int ID
        {
            get { return _ID; }
            set
            {
                if(_ID!=value){
                    _ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        Guid _QGID;
        public Guid QGID
        {
            get { return _QGID; }
            set
            {
                if(_QGID!=value){
                    _QGID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="QGID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        Guid _ExamGID;
        public Guid ExamGID
        {
            get { return _ExamGID; }
            set
            {
                if(_ExamGID!=value){
                    _ExamGID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ExamGID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _qContent;
        public string qContent
        {
            get { return _qContent; }
            set
            {
                if(_qContent!=value){
                    _qContent=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="qContent");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _qType;
        public int qType
        {
            get { return _qType; }
            set
            {
                if(_qType!=value){
                    _qType=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="qType");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _qSelectNum;
        public int qSelectNum
        {
            get { return _qSelectNum; }
            set
            {
                if(_qSelectNum!=value){
                    _qSelectNum=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="qSelectNum");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _qOrderNum;
        public int qOrderNum
        {
            get { return _qOrderNum; }
            set
            {
                if(_qOrderNum!=value){
                    _qOrderNum=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="qOrderNum");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _qAnswer;
        public string qAnswer
        {
            get { return _qAnswer; }
            set
            {
                if(_qAnswer!=value){
                    _qAnswer=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="qAnswer");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<WXExamDetail, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the WXExamPaper table in the WangxiaoCN Database.
    /// </summary>
    public partial class WXExamPaper: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<WXExamPaper> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<WXExamPaper>(new WangxiaoCN.WangxiaoCNDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<WXExamPaper> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(WXExamPaper item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                WXExamPaper item=new WXExamPaper();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<WXExamPaper> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        WangxiaoCN.WangxiaoCNDB _db;
        public WXExamPaper(string connectionString, string providerName) {

            _db=new WangxiaoCN.WangxiaoCNDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                WXExamPaper.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<WXExamPaper>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public WXExamPaper(){
             _db=new WangxiaoCN.WangxiaoCNDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public WXExamPaper(Expression<Func<WXExamPaper, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<WXExamPaper> GetRepo(string connectionString, string providerName){
            WangxiaoCN.WangxiaoCNDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new WangxiaoCN.WangxiaoCNDB();
            }else{
                db=new WangxiaoCN.WangxiaoCNDB(connectionString, providerName);
            }
            IRepository<WXExamPaper> _repo;
            
            if(db.TestMode){
                WXExamPaper.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<WXExamPaper>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<WXExamPaper> GetRepo(){
            return GetRepo("","");
        }
        
        public static WXExamPaper SingleOrDefault(Expression<Func<WXExamPaper, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            WXExamPaper single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static WXExamPaper SingleOrDefault(Expression<Func<WXExamPaper, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            WXExamPaper single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<WXExamPaper, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<WXExamPaper, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<WXExamPaper> Find(Expression<Func<WXExamPaper, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<WXExamPaper> Find(Expression<Func<WXExamPaper, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<WXExamPaper> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<WXExamPaper> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<WXExamPaper> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<WXExamPaper> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<WXExamPaper> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<WXExamPaper> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "ID";
        }

        public object KeyValue()
        {
            return this.ID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.eTitle.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(WXExamPaper)){
                WXExamPaper compare=(WXExamPaper)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.ID;
        }
        
        public string DescriptorValue()
        {
                            return this.eTitle.ToString();
                    }

        public string DescriptorColumn() {
            return "eTitle";
        }
        public static string GetKeyColumn()
        {
            return "ID";
        }        
        public static string GetDescriptorColumn()
        {
            return "eTitle";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _ID;
        public int ID
        {
            get { return _ID; }
            set
            {
                if(_ID!=value){
                    _ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        Guid _ExamGID;
        public Guid ExamGID
        {
            get { return _ExamGID; }
            set
            {
                if(_ExamGID!=value){
                    _ExamGID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ExamGID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        Guid _ClassGID;
        public Guid ClassGID
        {
            get { return _ClassGID; }
            set
            {
                if(_ClassGID!=value){
                    _ClassGID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ClassGID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _PvcID;
        public int PvcID
        {
            get { return _PvcID; }
            set
            {
                if(_PvcID!=value){
                    _PvcID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PvcID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _ExamTypeID;
        public int ExamTypeID
        {
            get { return _ExamTypeID; }
            set
            {
                if(_ExamTypeID!=value){
                    _ExamTypeID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ExamTypeID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _eTitle;
        public string eTitle
        {
            get { return _eTitle; }
            set
            {
                if(_eTitle!=value){
                    _eTitle=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="eTitle");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _eYear;
        public int eYear
        {
            get { return _eYear; }
            set
            {
                if(_eYear!=value){
                    _eYear=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="eYear");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _eStars;
        public int eStars
        {
            get { return _eStars; }
            set
            {
                if(_eStars!=value){
                    _eStars=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="eStars");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _eTotalScore;
        public int eTotalScore
        {
            get { return _eTotalScore; }
            set
            {
                if(_eTotalScore!=value){
                    _eTotalScore=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="eTotalScore");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _ePassingScore;
        public int ePassingScore
        {
            get { return _ePassingScore; }
            set
            {
                if(_ePassingScore!=value){
                    _ePassingScore=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ePassingScore");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _eFrom;
        public string eFrom
        {
            get { return _eFrom; }
            set
            {
                if(_eFrom!=value){
                    _eFrom=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="eFrom");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _eHot;
        public int eHot
        {
            get { return _eHot; }
            set
            {
                if(_eHot!=value){
                    _eHot=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="eHot");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _ePoints;
        public int ePoints
        {
            get { return _ePoints; }
            set
            {
                if(_ePoints!=value){
                    _ePoints=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ePoints");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<WXExamPaper, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the WXPointsBank table in the WangxiaoCN Database.
    /// </summary>
    public partial class WXPointsBank: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<WXPointsBank> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<WXPointsBank>(new WangxiaoCN.WangxiaoCNDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<WXPointsBank> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(WXPointsBank item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                WXPointsBank item=new WXPointsBank();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<WXPointsBank> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        WangxiaoCN.WangxiaoCNDB _db;
        public WXPointsBank(string connectionString, string providerName) {

            _db=new WangxiaoCN.WangxiaoCNDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                WXPointsBank.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<WXPointsBank>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public WXPointsBank(){
             _db=new WangxiaoCN.WangxiaoCNDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public WXPointsBank(Expression<Func<WXPointsBank, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<WXPointsBank> GetRepo(string connectionString, string providerName){
            WangxiaoCN.WangxiaoCNDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new WangxiaoCN.WangxiaoCNDB();
            }else{
                db=new WangxiaoCN.WangxiaoCNDB(connectionString, providerName);
            }
            IRepository<WXPointsBank> _repo;
            
            if(db.TestMode){
                WXPointsBank.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<WXPointsBank>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<WXPointsBank> GetRepo(){
            return GetRepo("","");
        }
        
        public static WXPointsBank SingleOrDefault(Expression<Func<WXPointsBank, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            WXPointsBank single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static WXPointsBank SingleOrDefault(Expression<Func<WXPointsBank, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            WXPointsBank single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<WXPointsBank, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<WXPointsBank, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<WXPointsBank> Find(Expression<Func<WXPointsBank, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<WXPointsBank> Find(Expression<Func<WXPointsBank, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<WXPointsBank> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<WXPointsBank> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<WXPointsBank> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<WXPointsBank> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<WXPointsBank> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<WXPointsBank> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "ID";
        }

        public object KeyValue()
        {
            return this.ID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.GID.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(WXPointsBank)){
                WXPointsBank compare=(WXPointsBank)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.ID;
        }
        
        public string DescriptorValue()
        {
                            return this.GID.ToString();
                    }

        public string DescriptorColumn() {
            return "GID";
        }
        public static string GetKeyColumn()
        {
            return "ID";
        }        
        public static string GetDescriptorColumn()
        {
            return "GID";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _ID;
        public int ID
        {
            get { return _ID; }
            set
            {
                if(_ID!=value){
                    _ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        Guid? _GID;
        public Guid? GID
        {
            get { return _GID; }
            set
            {
                if(_GID!=value){
                    _GID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="GID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _uid;
        public int? uid
        {
            get { return _uid; }
            set
            {
                if(_uid!=value){
                    _uid=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="uid");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _isBuyOrShopping;
        public int? isBuyOrShopping
        {
            get { return _isBuyOrShopping; }
            set
            {
                if(_isBuyOrShopping!=value){
                    _isBuyOrShopping=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="isBuyOrShopping");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _Points;
        public int? Points
        {
            get { return _Points; }
            set
            {
                if(_Points!=value){
                    _Points=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Points");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _intime;
        public DateTime? intime
        {
            get { return _intime; }
            set
            {
                if(_intime!=value){
                    _intime=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="intime");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<WXPointsBank, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the WXSysCity table in the WangxiaoCN Database.
    /// </summary>
    public partial class WXSysCity: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<WXSysCity> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<WXSysCity>(new WangxiaoCN.WangxiaoCNDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<WXSysCity> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(WXSysCity item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                WXSysCity item=new WXSysCity();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<WXSysCity> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        WangxiaoCN.WangxiaoCNDB _db;
        public WXSysCity(string connectionString, string providerName) {

            _db=new WangxiaoCN.WangxiaoCNDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                WXSysCity.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<WXSysCity>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public WXSysCity(){
             _db=new WangxiaoCN.WangxiaoCNDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public WXSysCity(Expression<Func<WXSysCity, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<WXSysCity> GetRepo(string connectionString, string providerName){
            WangxiaoCN.WangxiaoCNDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new WangxiaoCN.WangxiaoCNDB();
            }else{
                db=new WangxiaoCN.WangxiaoCNDB(connectionString, providerName);
            }
            IRepository<WXSysCity> _repo;
            
            if(db.TestMode){
                WXSysCity.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<WXSysCity>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<WXSysCity> GetRepo(){
            return GetRepo("","");
        }
        
        public static WXSysCity SingleOrDefault(Expression<Func<WXSysCity, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            WXSysCity single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static WXSysCity SingleOrDefault(Expression<Func<WXSysCity, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            WXSysCity single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<WXSysCity, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<WXSysCity, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<WXSysCity> Find(Expression<Func<WXSysCity, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<WXSysCity> Find(Expression<Func<WXSysCity, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<WXSysCity> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<WXSysCity> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<WXSysCity> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<WXSysCity> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<WXSysCity> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<WXSysCity> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "cName";
        }

        public object KeyValue()
        {
            return this.cName;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<string>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.cName.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(WXSysCity)){
                WXSysCity compare=(WXSysCity)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
                            return this.cName.ToString();
                    }

        public string DescriptorColumn() {
            return "cName";
        }
        public static string GetKeyColumn()
        {
            return "cName";
        }        
        public static string GetDescriptorColumn()
        {
            return "cName";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _cID;
        public int cID
        {
            get { return _cID; }
            set
            {
                if(_cID!=value){
                    _cID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="cID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _cName;
        public string cName
        {
            get { return _cName; }
            set
            {
                if(_cName!=value){
                    _cName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="cName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _pId;
        public int? pId
        {
            get { return _pId; }
            set
            {
                if(_pId!=value){
                    _pId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="pId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<WXSysCity, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the WXSysExamCategory table in the WangxiaoCN Database.
    /// </summary>
    public partial class WXSysExamCategory: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<WXSysExamCategory> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<WXSysExamCategory>(new WangxiaoCN.WangxiaoCNDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<WXSysExamCategory> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(WXSysExamCategory item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                WXSysExamCategory item=new WXSysExamCategory();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<WXSysExamCategory> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        WangxiaoCN.WangxiaoCNDB _db;
        public WXSysExamCategory(string connectionString, string providerName) {

            _db=new WangxiaoCN.WangxiaoCNDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                WXSysExamCategory.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<WXSysExamCategory>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public WXSysExamCategory(){
             _db=new WangxiaoCN.WangxiaoCNDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public WXSysExamCategory(Expression<Func<WXSysExamCategory, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<WXSysExamCategory> GetRepo(string connectionString, string providerName){
            WangxiaoCN.WangxiaoCNDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new WangxiaoCN.WangxiaoCNDB();
            }else{
                db=new WangxiaoCN.WangxiaoCNDB(connectionString, providerName);
            }
            IRepository<WXSysExamCategory> _repo;
            
            if(db.TestMode){
                WXSysExamCategory.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<WXSysExamCategory>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<WXSysExamCategory> GetRepo(){
            return GetRepo("","");
        }
        
        public static WXSysExamCategory SingleOrDefault(Expression<Func<WXSysExamCategory, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            WXSysExamCategory single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static WXSysExamCategory SingleOrDefault(Expression<Func<WXSysExamCategory, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            WXSysExamCategory single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<WXSysExamCategory, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<WXSysExamCategory, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<WXSysExamCategory> Find(Expression<Func<WXSysExamCategory, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<WXSysExamCategory> Find(Expression<Func<WXSysExamCategory, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<WXSysExamCategory> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<WXSysExamCategory> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<WXSysExamCategory> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<WXSysExamCategory> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<WXSysExamCategory> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<WXSysExamCategory> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "ID";
        }

        public object KeyValue()
        {
            return this.ID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.className.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(WXSysExamCategory)){
                WXSysExamCategory compare=(WXSysExamCategory)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.ID;
        }
        
        public string DescriptorValue()
        {
                            return this.className.ToString();
                    }

        public string DescriptorColumn() {
            return "className";
        }
        public static string GetKeyColumn()
        {
            return "ID";
        }        
        public static string GetDescriptorColumn()
        {
            return "className";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _ID;
        public int ID
        {
            get { return _ID; }
            set
            {
                if(_ID!=value){
                    _ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        Guid _GID;
        public Guid GID
        {
            get { return _GID; }
            set
            {
                if(_GID!=value){
                    _GID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="GID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        Guid _PID;
        public Guid PID
        {
            get { return _PID; }
            set
            {
                if(_PID!=value){
                    _PID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _className;
        public string className
        {
            get { return _className; }
            set
            {
                if(_className!=value){
                    _className=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="className");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _path;
        public string path
        {
            get { return _path; }
            set
            {
                if(_path!=value){
                    _path=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="path");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _isDeep;
        public int? isDeep
        {
            get { return _isDeep; }
            set
            {
                if(_isDeep!=value){
                    _isDeep=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="isDeep");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<WXSysExamCategory, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the WXSysExamQstType table in the WangxiaoCN Database.
    /// </summary>
    public partial class WXSysExamQstType: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<WXSysExamQstType> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<WXSysExamQstType>(new WangxiaoCN.WangxiaoCNDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<WXSysExamQstType> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(WXSysExamQstType item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                WXSysExamQstType item=new WXSysExamQstType();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<WXSysExamQstType> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        WangxiaoCN.WangxiaoCNDB _db;
        public WXSysExamQstType(string connectionString, string providerName) {

            _db=new WangxiaoCN.WangxiaoCNDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                WXSysExamQstType.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<WXSysExamQstType>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public WXSysExamQstType(){
             _db=new WangxiaoCN.WangxiaoCNDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public WXSysExamQstType(Expression<Func<WXSysExamQstType, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<WXSysExamQstType> GetRepo(string connectionString, string providerName){
            WangxiaoCN.WangxiaoCNDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new WangxiaoCN.WangxiaoCNDB();
            }else{
                db=new WangxiaoCN.WangxiaoCNDB(connectionString, providerName);
            }
            IRepository<WXSysExamQstType> _repo;
            
            if(db.TestMode){
                WXSysExamQstType.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<WXSysExamQstType>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<WXSysExamQstType> GetRepo(){
            return GetRepo("","");
        }
        
        public static WXSysExamQstType SingleOrDefault(Expression<Func<WXSysExamQstType, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            WXSysExamQstType single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static WXSysExamQstType SingleOrDefault(Expression<Func<WXSysExamQstType, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            WXSysExamQstType single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<WXSysExamQstType, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<WXSysExamQstType, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<WXSysExamQstType> Find(Expression<Func<WXSysExamQstType, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<WXSysExamQstType> Find(Expression<Func<WXSysExamQstType, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<WXSysExamQstType> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<WXSysExamQstType> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<WXSysExamQstType> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<WXSysExamQstType> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<WXSysExamQstType> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<WXSysExamQstType> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "ID";
        }

        public object KeyValue()
        {
            return this.ID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.TypeName.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(WXSysExamQstType)){
                WXSysExamQstType compare=(WXSysExamQstType)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.ID;
        }
        
        public string DescriptorValue()
        {
                            return this.TypeName.ToString();
                    }

        public string DescriptorColumn() {
            return "TypeName";
        }
        public static string GetKeyColumn()
        {
            return "ID";
        }        
        public static string GetDescriptorColumn()
        {
            return "TypeName";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _ID;
        public int ID
        {
            get { return _ID; }
            set
            {
                if(_ID!=value){
                    _ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _TypeName;
        public string TypeName
        {
            get { return _TypeName; }
            set
            {
                if(_TypeName!=value){
                    _TypeName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="TypeName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<WXSysExamQstType, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the WXSysExamType table in the WangxiaoCN Database.
    /// </summary>
    public partial class WXSysExamType: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<WXSysExamType> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<WXSysExamType>(new WangxiaoCN.WangxiaoCNDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<WXSysExamType> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(WXSysExamType item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                WXSysExamType item=new WXSysExamType();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<WXSysExamType> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        WangxiaoCN.WangxiaoCNDB _db;
        public WXSysExamType(string connectionString, string providerName) {

            _db=new WangxiaoCN.WangxiaoCNDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                WXSysExamType.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<WXSysExamType>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public WXSysExamType(){
             _db=new WangxiaoCN.WangxiaoCNDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public WXSysExamType(Expression<Func<WXSysExamType, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<WXSysExamType> GetRepo(string connectionString, string providerName){
            WangxiaoCN.WangxiaoCNDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new WangxiaoCN.WangxiaoCNDB();
            }else{
                db=new WangxiaoCN.WangxiaoCNDB(connectionString, providerName);
            }
            IRepository<WXSysExamType> _repo;
            
            if(db.TestMode){
                WXSysExamType.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<WXSysExamType>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<WXSysExamType> GetRepo(){
            return GetRepo("","");
        }
        
        public static WXSysExamType SingleOrDefault(Expression<Func<WXSysExamType, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            WXSysExamType single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static WXSysExamType SingleOrDefault(Expression<Func<WXSysExamType, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            WXSysExamType single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<WXSysExamType, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<WXSysExamType, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<WXSysExamType> Find(Expression<Func<WXSysExamType, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<WXSysExamType> Find(Expression<Func<WXSysExamType, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<WXSysExamType> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<WXSysExamType> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<WXSysExamType> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<WXSysExamType> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<WXSysExamType> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<WXSysExamType> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "ID";
        }

        public object KeyValue()
        {
            return this.ID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.ExamType.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(WXSysExamType)){
                WXSysExamType compare=(WXSysExamType)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.ID;
        }
        
        public string DescriptorValue()
        {
                            return this.ExamType.ToString();
                    }

        public string DescriptorColumn() {
            return "ExamType";
        }
        public static string GetKeyColumn()
        {
            return "ID";
        }        
        public static string GetDescriptorColumn()
        {
            return "ExamType";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _ID;
        public int ID
        {
            get { return _ID; }
            set
            {
                if(_ID!=value){
                    _ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _ExamType;
        public string ExamType
        {
            get { return _ExamType; }
            set
            {
                if(_ExamType!=value){
                    _ExamType=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ExamType");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<WXSysExamType, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the WXSysProvince table in the WangxiaoCN Database.
    /// </summary>
    public partial class WXSysProvince: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<WXSysProvince> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<WXSysProvince>(new WangxiaoCN.WangxiaoCNDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<WXSysProvince> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(WXSysProvince item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                WXSysProvince item=new WXSysProvince();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<WXSysProvince> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        WangxiaoCN.WangxiaoCNDB _db;
        public WXSysProvince(string connectionString, string providerName) {

            _db=new WangxiaoCN.WangxiaoCNDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                WXSysProvince.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<WXSysProvince>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public WXSysProvince(){
             _db=new WangxiaoCN.WangxiaoCNDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public WXSysProvince(Expression<Func<WXSysProvince, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<WXSysProvince> GetRepo(string connectionString, string providerName){
            WangxiaoCN.WangxiaoCNDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new WangxiaoCN.WangxiaoCNDB();
            }else{
                db=new WangxiaoCN.WangxiaoCNDB(connectionString, providerName);
            }
            IRepository<WXSysProvince> _repo;
            
            if(db.TestMode){
                WXSysProvince.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<WXSysProvince>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<WXSysProvince> GetRepo(){
            return GetRepo("","");
        }
        
        public static WXSysProvince SingleOrDefault(Expression<Func<WXSysProvince, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            WXSysProvince single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static WXSysProvince SingleOrDefault(Expression<Func<WXSysProvince, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            WXSysProvince single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<WXSysProvince, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<WXSysProvince, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<WXSysProvince> Find(Expression<Func<WXSysProvince, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<WXSysProvince> Find(Expression<Func<WXSysProvince, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<WXSysProvince> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<WXSysProvince> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<WXSysProvince> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<WXSysProvince> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<WXSysProvince> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<WXSysProvince> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "pID";
        }

        public object KeyValue()
        {
            return this.pID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.pName.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(WXSysProvince)){
                WXSysProvince compare=(WXSysProvince)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.pID;
        }
        
        public string DescriptorValue()
        {
                            return this.pName.ToString();
                    }

        public string DescriptorColumn() {
            return "pName";
        }
        public static string GetKeyColumn()
        {
            return "pID";
        }        
        public static string GetDescriptorColumn()
        {
            return "pName";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _pID;
        public int pID
        {
            get { return _pID; }
            set
            {
                if(_pID!=value){
                    _pID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="pID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _pName;
        public string pName
        {
            get { return _pName; }
            set
            {
                if(_pName!=value){
                    _pName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="pName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<WXSysProvince, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the WXSysYears table in the WangxiaoCN Database.
    /// </summary>
    public partial class WXSysYear: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<WXSysYear> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<WXSysYear>(new WangxiaoCN.WangxiaoCNDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<WXSysYear> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(WXSysYear item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                WXSysYear item=new WXSysYear();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<WXSysYear> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        WangxiaoCN.WangxiaoCNDB _db;
        public WXSysYear(string connectionString, string providerName) {

            _db=new WangxiaoCN.WangxiaoCNDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                WXSysYear.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<WXSysYear>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public WXSysYear(){
             _db=new WangxiaoCN.WangxiaoCNDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public WXSysYear(Expression<Func<WXSysYear, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<WXSysYear> GetRepo(string connectionString, string providerName){
            WangxiaoCN.WangxiaoCNDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new WangxiaoCN.WangxiaoCNDB();
            }else{
                db=new WangxiaoCN.WangxiaoCNDB(connectionString, providerName);
            }
            IRepository<WXSysYear> _repo;
            
            if(db.TestMode){
                WXSysYear.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<WXSysYear>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<WXSysYear> GetRepo(){
            return GetRepo("","");
        }
        
        public static WXSysYear SingleOrDefault(Expression<Func<WXSysYear, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            WXSysYear single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static WXSysYear SingleOrDefault(Expression<Func<WXSysYear, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            WXSysYear single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<WXSysYear, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<WXSysYear, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<WXSysYear> Find(Expression<Func<WXSysYear, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<WXSysYear> Find(Expression<Func<WXSysYear, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<WXSysYear> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<WXSysYear> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<WXSysYear> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<WXSysYear> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<WXSysYear> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<WXSysYear> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "ID";
        }

        public object KeyValue()
        {
            return this.ID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.Years.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(WXSysYear)){
                WXSysYear compare=(WXSysYear)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.ID;
        }
        
        public string DescriptorValue()
        {
                            return this.Years.ToString();
                    }

        public string DescriptorColumn() {
            return "Years";
        }
        public static string GetKeyColumn()
        {
            return "ID";
        }        
        public static string GetDescriptorColumn()
        {
            return "Years";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _ID;
        public int ID
        {
            get { return _ID; }
            set
            {
                if(_ID!=value){
                    _ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _Years;
        public int Years
        {
            get { return _Years; }
            set
            {
                if(_Years!=value){
                    _Years=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Years");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<WXSysYear, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the WXUserDetails table in the WangxiaoCN Database.
    /// </summary>
    public partial class WXUserDetail: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<WXUserDetail> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<WXUserDetail>(new WangxiaoCN.WangxiaoCNDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<WXUserDetail> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(WXUserDetail item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                WXUserDetail item=new WXUserDetail();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<WXUserDetail> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        WangxiaoCN.WangxiaoCNDB _db;
        public WXUserDetail(string connectionString, string providerName) {

            _db=new WangxiaoCN.WangxiaoCNDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                WXUserDetail.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<WXUserDetail>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public WXUserDetail(){
             _db=new WangxiaoCN.WangxiaoCNDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public WXUserDetail(Expression<Func<WXUserDetail, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<WXUserDetail> GetRepo(string connectionString, string providerName){
            WangxiaoCN.WangxiaoCNDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new WangxiaoCN.WangxiaoCNDB();
            }else{
                db=new WangxiaoCN.WangxiaoCNDB(connectionString, providerName);
            }
            IRepository<WXUserDetail> _repo;
            
            if(db.TestMode){
                WXUserDetail.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<WXUserDetail>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<WXUserDetail> GetRepo(){
            return GetRepo("","");
        }
        
        public static WXUserDetail SingleOrDefault(Expression<Func<WXUserDetail, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            WXUserDetail single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static WXUserDetail SingleOrDefault(Expression<Func<WXUserDetail, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            WXUserDetail single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<WXUserDetail, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<WXUserDetail, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<WXUserDetail> Find(Expression<Func<WXUserDetail, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<WXUserDetail> Find(Expression<Func<WXUserDetail, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<WXUserDetail> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<WXUserDetail> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<WXUserDetail> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<WXUserDetail> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<WXUserDetail> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<WXUserDetail> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "ID";
        }

        public object KeyValue()
        {
            return this.ID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.uid.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(WXUserDetail)){
                WXUserDetail compare=(WXUserDetail)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.ID;
        }
        
        public string DescriptorValue()
        {
                            return this.uid.ToString();
                    }

        public string DescriptorColumn() {
            return "uid";
        }
        public static string GetKeyColumn()
        {
            return "ID";
        }        
        public static string GetDescriptorColumn()
        {
            return "uid";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _ID;
        public int ID
        {
            get { return _ID; }
            set
            {
                if(_ID!=value){
                    _ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _uid;
        public int? uid
        {
            get { return _uid; }
            set
            {
                if(_uid!=value){
                    _uid=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="uid");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<WXUserDetail, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the WXUsers table in the WangxiaoCN Database.
    /// </summary>
    public partial class WXUser: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<WXUser> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<WXUser>(new WangxiaoCN.WangxiaoCNDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<WXUser> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(WXUser item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                WXUser item=new WXUser();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<WXUser> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        WangxiaoCN.WangxiaoCNDB _db;
        public WXUser(string connectionString, string providerName) {

            _db=new WangxiaoCN.WangxiaoCNDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                WXUser.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<WXUser>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public WXUser(){
             _db=new WangxiaoCN.WangxiaoCNDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public WXUser(Expression<Func<WXUser, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<WXUser> GetRepo(string connectionString, string providerName){
            WangxiaoCN.WangxiaoCNDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new WangxiaoCN.WangxiaoCNDB();
            }else{
                db=new WangxiaoCN.WangxiaoCNDB(connectionString, providerName);
            }
            IRepository<WXUser> _repo;
            
            if(db.TestMode){
                WXUser.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<WXUser>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<WXUser> GetRepo(){
            return GetRepo("","");
        }
        
        public static WXUser SingleOrDefault(Expression<Func<WXUser, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            WXUser single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static WXUser SingleOrDefault(Expression<Func<WXUser, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            WXUser single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<WXUser, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<WXUser, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<WXUser> Find(Expression<Func<WXUser, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<WXUser> Find(Expression<Func<WXUser, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<WXUser> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<WXUser> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<WXUser> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<WXUser> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<WXUser> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<WXUser> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "ID";
        }

        public object KeyValue()
        {
            return this.ID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.username.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(WXUser)){
                WXUser compare=(WXUser)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.ID;
        }
        
        public string DescriptorValue()
        {
                            return this.username.ToString();
                    }

        public string DescriptorColumn() {
            return "username";
        }
        public static string GetKeyColumn()
        {
            return "ID";
        }        
        public static string GetDescriptorColumn()
        {
            return "username";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _ID;
        public int ID
        {
            get { return _ID; }
            set
            {
                if(_ID!=value){
                    _ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        Guid? _GID;
        public Guid? GID
        {
            get { return _GID; }
            set
            {
                if(_GID!=value){
                    _GID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="GID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _uid;
        public int? uid
        {
            get { return _uid; }
            set
            {
                if(_uid!=value){
                    _uid=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="uid");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _username;
        public string username
        {
            get { return _username; }
            set
            {
                if(_username!=value){
                    _username=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="username");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _Points;
        public int? Points
        {
            get { return _Points; }
            set
            {
                if(_Points!=value){
                    _Points=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Points");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _intime;
        public DateTime? intime
        {
            get { return _intime; }
            set
            {
                if(_intime!=value){
                    _intime=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="intime");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<WXUser, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
}
