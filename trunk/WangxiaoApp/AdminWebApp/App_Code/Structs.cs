


using System;
using SubSonic.Schema;
using System.Collections.Generic;
using SubSonic.DataProviders;
using System.Data;

namespace WangxiaoCN {
	
        /// <summary>
        /// Table: WXSysProvince
        /// Primary Key: pID
        /// </summary>

        public class WXSysProvinceTable: DatabaseTable {
            
            public WXSysProvinceTable(IDataProvider provider):base("WXSysProvince",provider){
                ClassName = "WXSysProvince";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("pID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("pName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 32
                });
                    
                
                
            }

            public IColumn pID{
                get{
                    return this.GetColumn("pID");
                }
            }
				
   			public static string pIDColumn{
			      get{
        			return "pID";
      			}
		    }
            
            public IColumn pName{
                get{
                    return this.GetColumn("pName");
                }
            }
				
   			public static string pNameColumn{
			      get{
        			return "pName";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: WXSysCity
        /// Primary Key: cName
        /// </summary>

        public class WXSysCityTable: DatabaseTable {
            
            public WXSysCityTable(IDataProvider provider):base("WXSysCity",provider){
                ClassName = "WXSysCity";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("cID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("cName", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 32
                });

                Columns.Add(new DatabaseColumn("pId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }

            public IColumn cID{
                get{
                    return this.GetColumn("cID");
                }
            }
				
   			public static string cIDColumn{
			      get{
        			return "cID";
      			}
		    }
            
            public IColumn cName{
                get{
                    return this.GetColumn("cName");
                }
            }
				
   			public static string cNameColumn{
			      get{
        			return "cName";
      			}
		    }
            
            public IColumn pId{
                get{
                    return this.GetColumn("pId");
                }
            }
				
   			public static string pIdColumn{
			      get{
        			return "pId";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: WXExamDetail
        /// Primary Key: ID
        /// </summary>

        public class WXExamDetailTable: DatabaseTable {
            
            public WXExamDetailTable(IDataProvider provider):base("WXExamDetail",provider){
                ClassName = "WXExamDetail";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("ID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("examID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("qContent", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1000
                });

                Columns.Add(new DatabaseColumn("qType", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("qSelectNum", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("qOrderNum", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("qAnswer", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2000
                });
                    
                
                
            }

            public IColumn ID{
                get{
                    return this.GetColumn("ID");
                }
            }
				
   			public static string IDColumn{
			      get{
        			return "ID";
      			}
		    }
            
            public IColumn examID{
                get{
                    return this.GetColumn("examID");
                }
            }
				
   			public static string examIDColumn{
			      get{
        			return "examID";
      			}
		    }
            
            public IColumn qContent{
                get{
                    return this.GetColumn("qContent");
                }
            }
				
   			public static string qContentColumn{
			      get{
        			return "qContent";
      			}
		    }
            
            public IColumn qType{
                get{
                    return this.GetColumn("qType");
                }
            }
				
   			public static string qTypeColumn{
			      get{
        			return "qType";
      			}
		    }
            
            public IColumn qSelectNum{
                get{
                    return this.GetColumn("qSelectNum");
                }
            }
				
   			public static string qSelectNumColumn{
			      get{
        			return "qSelectNum";
      			}
		    }
            
            public IColumn qOrderNum{
                get{
                    return this.GetColumn("qOrderNum");
                }
            }
				
   			public static string qOrderNumColumn{
			      get{
        			return "qOrderNum";
      			}
		    }
            
            public IColumn qAnswer{
                get{
                    return this.GetColumn("qAnswer");
                }
            }
				
   			public static string qAnswerColumn{
			      get{
        			return "qAnswer";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: WXAdminPowerCategory
        /// Primary Key: ID
        /// </summary>

        public class WXAdminPowerCategoryTable: DatabaseTable {
            
            public WXAdminPowerCategoryTable(IDataProvider provider):base("WXAdminPowerCategory",provider){
                ClassName = "WXAdminPowerCategory";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("ID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("LevelName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("LevelNum", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }

            public IColumn ID{
                get{
                    return this.GetColumn("ID");
                }
            }
				
   			public static string IDColumn{
			      get{
        			return "ID";
      			}
		    }
            
            public IColumn LevelName{
                get{
                    return this.GetColumn("LevelName");
                }
            }
				
   			public static string LevelNameColumn{
			      get{
        			return "LevelName";
      			}
		    }
            
            public IColumn LevelNum{
                get{
                    return this.GetColumn("LevelNum");
                }
            }
				
   			public static string LevelNumColumn{
			      get{
        			return "LevelNum";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: WXExamPaper
        /// Primary Key: ID
        /// </summary>

        public class WXExamPaperTable: DatabaseTable {
            
            public WXExamPaperTable(IDataProvider provider):base("WXExamPaper",provider){
                ClassName = "WXExamPaper";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("ID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("classid", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("pid", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("eTitle", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 200
                });

                Columns.Add(new DatabaseColumn("eYear", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("eStars", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("eTotalScore", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ePassingScore", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("eFrom", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("eHot", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ePoints", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }

            public IColumn ID{
                get{
                    return this.GetColumn("ID");
                }
            }
				
   			public static string IDColumn{
			      get{
        			return "ID";
      			}
		    }
            
            public IColumn classid{
                get{
                    return this.GetColumn("classid");
                }
            }
				
   			public static string classidColumn{
			      get{
        			return "classid";
      			}
		    }
            
            public IColumn pid{
                get{
                    return this.GetColumn("pid");
                }
            }
				
   			public static string pidColumn{
			      get{
        			return "pid";
      			}
		    }
            
            public IColumn eTitle{
                get{
                    return this.GetColumn("eTitle");
                }
            }
				
   			public static string eTitleColumn{
			      get{
        			return "eTitle";
      			}
		    }
            
            public IColumn eYear{
                get{
                    return this.GetColumn("eYear");
                }
            }
				
   			public static string eYearColumn{
			      get{
        			return "eYear";
      			}
		    }
            
            public IColumn eStars{
                get{
                    return this.GetColumn("eStars");
                }
            }
				
   			public static string eStarsColumn{
			      get{
        			return "eStars";
      			}
		    }
            
            public IColumn eTotalScore{
                get{
                    return this.GetColumn("eTotalScore");
                }
            }
				
   			public static string eTotalScoreColumn{
			      get{
        			return "eTotalScore";
      			}
		    }
            
            public IColumn ePassingScore{
                get{
                    return this.GetColumn("ePassingScore");
                }
            }
				
   			public static string ePassingScoreColumn{
			      get{
        			return "ePassingScore";
      			}
		    }
            
            public IColumn eFrom{
                get{
                    return this.GetColumn("eFrom");
                }
            }
				
   			public static string eFromColumn{
			      get{
        			return "eFrom";
      			}
		    }
            
            public IColumn eHot{
                get{
                    return this.GetColumn("eHot");
                }
            }
				
   			public static string eHotColumn{
			      get{
        			return "eHot";
      			}
		    }
            
            public IColumn ePoints{
                get{
                    return this.GetColumn("ePoints");
                }
            }
				
   			public static string ePointsColumn{
			      get{
        			return "ePoints";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: WXAdminUsers
        /// Primary Key: ID
        /// </summary>

        public class WXAdminUsersTable: DatabaseTable {
            
            public WXAdminUsersTable(IDataProvider provider):base("WXAdminUsers",provider){
                ClassName = "WXAdminUser";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("ID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("GID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Guid,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("AdminUserName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("AdminPassWord", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("AdminLevelID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }

            public IColumn ID{
                get{
                    return this.GetColumn("ID");
                }
            }
				
   			public static string IDColumn{
			      get{
        			return "ID";
      			}
		    }
            
            public IColumn GID{
                get{
                    return this.GetColumn("GID");
                }
            }
				
   			public static string GIDColumn{
			      get{
        			return "GID";
      			}
		    }
            
            public IColumn AdminUserName{
                get{
                    return this.GetColumn("AdminUserName");
                }
            }
				
   			public static string AdminUserNameColumn{
			      get{
        			return "AdminUserName";
      			}
		    }
            
            public IColumn AdminPassWord{
                get{
                    return this.GetColumn("AdminPassWord");
                }
            }
				
   			public static string AdminPassWordColumn{
			      get{
        			return "AdminPassWord";
      			}
		    }
            
            public IColumn AdminLevelID{
                get{
                    return this.GetColumn("AdminLevelID");
                }
            }
				
   			public static string AdminLevelIDColumn{
			      get{
        			return "AdminLevelID";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: WXPointsBank
        /// Primary Key: ID
        /// </summary>

        public class WXPointsBankTable: DatabaseTable {
            
            public WXPointsBankTable(IDataProvider provider):base("WXPointsBank",provider){
                ClassName = "WXPointsBank";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("ID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("GID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Guid,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("uid", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("isBuyOrShopping", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Points", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("intime", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }

            public IColumn ID{
                get{
                    return this.GetColumn("ID");
                }
            }
				
   			public static string IDColumn{
			      get{
        			return "ID";
      			}
		    }
            
            public IColumn GID{
                get{
                    return this.GetColumn("GID");
                }
            }
				
   			public static string GIDColumn{
			      get{
        			return "GID";
      			}
		    }
            
            public IColumn uid{
                get{
                    return this.GetColumn("uid");
                }
            }
				
   			public static string uidColumn{
			      get{
        			return "uid";
      			}
		    }
            
            public IColumn isBuyOrShopping{
                get{
                    return this.GetColumn("isBuyOrShopping");
                }
            }
				
   			public static string isBuyOrShoppingColumn{
			      get{
        			return "isBuyOrShopping";
      			}
		    }
            
            public IColumn Points{
                get{
                    return this.GetColumn("Points");
                }
            }
				
   			public static string PointsColumn{
			      get{
        			return "Points";
      			}
		    }
            
            public IColumn intime{
                get{
                    return this.GetColumn("intime");
                }
            }
				
   			public static string intimeColumn{
			      get{
        			return "intime";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: WXUsers
        /// Primary Key: ID
        /// </summary>

        public class WXUsersTable: DatabaseTable {
            
            public WXUsersTable(IDataProvider provider):base("WXUsers",provider){
                ClassName = "WXUser";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("ID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("GID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Guid,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("uid", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("username", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("Points", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("intime", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }

            public IColumn ID{
                get{
                    return this.GetColumn("ID");
                }
            }
				
   			public static string IDColumn{
			      get{
        			return "ID";
      			}
		    }
            
            public IColumn GID{
                get{
                    return this.GetColumn("GID");
                }
            }
				
   			public static string GIDColumn{
			      get{
        			return "GID";
      			}
		    }
            
            public IColumn uid{
                get{
                    return this.GetColumn("uid");
                }
            }
				
   			public static string uidColumn{
			      get{
        			return "uid";
      			}
		    }
            
            public IColumn username{
                get{
                    return this.GetColumn("username");
                }
            }
				
   			public static string usernameColumn{
			      get{
        			return "username";
      			}
		    }
            
            public IColumn Points{
                get{
                    return this.GetColumn("Points");
                }
            }
				
   			public static string PointsColumn{
			      get{
        			return "Points";
      			}
		    }
            
            public IColumn intime{
                get{
                    return this.GetColumn("intime");
                }
            }
				
   			public static string intimeColumn{
			      get{
        			return "intime";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: WXSysExamCategory
        /// Primary Key: ID
        /// </summary>

        public class WXSysExamCategoryTable: DatabaseTable {
            
            public WXSysExamCategoryTable(IDataProvider provider):base("WXSysExamCategory",provider){
                ClassName = "WXSysExamCategory";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("ID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("GID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Guid,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("PID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Guid,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("className", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 200
                });

                Columns.Add(new DatabaseColumn("path", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 4000
                });
                    
                
                
            }

            public IColumn ID{
                get{
                    return this.GetColumn("ID");
                }
            }
				
   			public static string IDColumn{
			      get{
        			return "ID";
      			}
		    }
            
            public IColumn GID{
                get{
                    return this.GetColumn("GID");
                }
            }
				
   			public static string GIDColumn{
			      get{
        			return "GID";
      			}
		    }
            
            public IColumn PID{
                get{
                    return this.GetColumn("PID");
                }
            }
				
   			public static string PIDColumn{
			      get{
        			return "PID";
      			}
		    }
            
            public IColumn className{
                get{
                    return this.GetColumn("className");
                }
            }
				
   			public static string classNameColumn{
			      get{
        			return "className";
      			}
		    }
            
            public IColumn path{
                get{
                    return this.GetColumn("path");
                }
            }
				
   			public static string pathColumn{
			      get{
        			return "path";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: WXUserDetails
        /// Primary Key: ID
        /// </summary>

        public class WXUserDetailsTable: DatabaseTable {
            
            public WXUserDetailsTable(IDataProvider provider):base("WXUserDetails",provider){
                ClassName = "WXUserDetail";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("ID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("uid", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }

            public IColumn ID{
                get{
                    return this.GetColumn("ID");
                }
            }
				
   			public static string IDColumn{
			      get{
        			return "ID";
      			}
		    }
            
            public IColumn uid{
                get{
                    return this.GetColumn("uid");
                }
            }
				
   			public static string uidColumn{
			      get{
        			return "uid";
      			}
		    }
            
                    
        }
        
}