


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

                Columns.Add(new DatabaseColumn("isDeep", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ksID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("isBottom", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("iCount", this)
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
            
            public IColumn isDeep{
                get{
                    return this.GetColumn("isDeep");
                }
            }
				
   			public static string isDeepColumn{
			      get{
        			return "isDeep";
      			}
		    }
            
            public IColumn ksID{
                get{
                    return this.GetColumn("ksID");
                }
            }
				
   			public static string ksIDColumn{
			      get{
        			return "ksID";
      			}
		    }
            
            public IColumn isBottom{
                get{
                    return this.GetColumn("isBottom");
                }
            }
				
   			public static string isBottomColumn{
			      get{
        			return "isBottom";
      			}
		    }
            
            public IColumn iCount{
                get{
                    return this.GetColumn("iCount");
                }
            }
				
   			public static string iCountColumn{
			      get{
        			return "iCount";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: WXSysYears
        /// Primary Key: ID
        /// </summary>

        public class WXSysYearsTable: DatabaseTable {
            
            public WXSysYearsTable(IDataProvider provider):base("WXSysYears",provider){
                ClassName = "WXSysYear";
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

                Columns.Add(new DatabaseColumn("Years", this)
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
            
            public IColumn Years{
                get{
                    return this.GetColumn("Years");
                }
            }
				
   			public static string YearsColumn{
			      get{
        			return "Years";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: WXSysExamQstType
        /// Primary Key: ID
        /// </summary>

        public class WXSysExamQstTypeTable: DatabaseTable {
            
            public WXSysExamQstTypeTable(IDataProvider provider):base("WXSysExamQstType",provider){
                ClassName = "WXSysExamQstType";
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

                Columns.Add(new DatabaseColumn("TypeName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
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
            
            public IColumn TypeName{
                get{
                    return this.GetColumn("TypeName");
                }
            }
				
   			public static string TypeNameColumn{
			      get{
        			return "TypeName";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: WXSysExamType
        /// Primary Key: ID
        /// </summary>

        public class WXSysExamTypeTable: DatabaseTable {
            
            public WXSysExamTypeTable(IDataProvider provider):base("WXSysExamType",provider){
                ClassName = "WXSysExamType";
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

                Columns.Add(new DatabaseColumn("ExamType", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
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
            
            public IColumn ExamType{
                get{
                    return this.GetColumn("ExamType");
                }
            }
				
   			public static string ExamTypeColumn{
			      get{
        			return "ExamType";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: WXAdmin_Logs_Opration
        /// Primary Key: OprateID
        /// </summary>

        public class WXAdmin_Logs_OprationTable: DatabaseTable {
            
            public WXAdmin_Logs_OprationTable(IDataProvider provider):base("WXAdmin_Logs_Opration",provider){
                ClassName = "WXAdmin_Logs_Opration";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("OprateID", this)
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

                Columns.Add(new DatabaseColumn("AdminID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Opration", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("GGID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Guid,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("inTime", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }

            public IColumn OprateID{
                get{
                    return this.GetColumn("OprateID");
                }
            }
				
   			public static string OprateIDColumn{
			      get{
        			return "OprateID";
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
            
            public IColumn AdminID{
                get{
                    return this.GetColumn("AdminID");
                }
            }
				
   			public static string AdminIDColumn{
			      get{
        			return "AdminID";
      			}
		    }
            
            public IColumn Opration{
                get{
                    return this.GetColumn("Opration");
                }
            }
				
   			public static string OprationColumn{
			      get{
        			return "Opration";
      			}
		    }
            
            public IColumn GGID{
                get{
                    return this.GetColumn("GGID");
                }
            }
				
   			public static string GGIDColumn{
			      get{
        			return "GGID";
      			}
		    }
            
            public IColumn inTime{
                get{
                    return this.GetColumn("inTime");
                }
            }
				
   			public static string inTimeColumn{
			      get{
        			return "inTime";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: WXAdmin_Power_Tree
        /// Primary Key: ID
        /// </summary>

        public class WXAdmin_Power_TreeTable: DatabaseTable {
            
            public WXAdmin_Power_TreeTable(IDataProvider provider):base("WXAdmin_Power_Tree",provider){
                ClassName = "WXAdmin_Power_Tree";
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

                Columns.Add(new DatabaseColumn("AdminID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("GGID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Guid,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("CURD", this)
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
            
            public IColumn AdminID{
                get{
                    return this.GetColumn("AdminID");
                }
            }
				
   			public static string AdminIDColumn{
			      get{
        			return "AdminID";
      			}
		    }
            
            public IColumn GGID{
                get{
                    return this.GetColumn("GGID");
                }
            }
				
   			public static string GGIDColumn{
			      get{
        			return "GGID";
      			}
		    }
            
            public IColumn CURD{
                get{
                    return this.GetColumn("CURD");
                }
            }
				
   			public static string CURDColumn{
			      get{
        			return "CURD";
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

                Columns.Add(new DatabaseColumn("ExamGID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Guid,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ClassGID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Guid,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("PvcID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ExamTypeID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("eTitle", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 200
                });

                Columns.Add(new DatabaseColumn("eYear", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("eStars", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("eTotalScore", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ePassingScore", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("eFrom", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("eHot", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ePoints", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("CreateID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("CreateTime", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("EditID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("EditTime", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("DelID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("DelTime", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("tExamID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("tKSID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("inTime", this)
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
            
            public IColumn ExamGID{
                get{
                    return this.GetColumn("ExamGID");
                }
            }
				
   			public static string ExamGIDColumn{
			      get{
        			return "ExamGID";
      			}
		    }
            
            public IColumn ClassGID{
                get{
                    return this.GetColumn("ClassGID");
                }
            }
				
   			public static string ClassGIDColumn{
			      get{
        			return "ClassGID";
      			}
		    }
            
            public IColumn PvcID{
                get{
                    return this.GetColumn("PvcID");
                }
            }
				
   			public static string PvcIDColumn{
			      get{
        			return "PvcID";
      			}
		    }
            
            public IColumn ExamTypeID{
                get{
                    return this.GetColumn("ExamTypeID");
                }
            }
				
   			public static string ExamTypeIDColumn{
			      get{
        			return "ExamTypeID";
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
            
            public IColumn CreateID{
                get{
                    return this.GetColumn("CreateID");
                }
            }
				
   			public static string CreateIDColumn{
			      get{
        			return "CreateID";
      			}
		    }
            
            public IColumn CreateTime{
                get{
                    return this.GetColumn("CreateTime");
                }
            }
				
   			public static string CreateTimeColumn{
			      get{
        			return "CreateTime";
      			}
		    }
            
            public IColumn EditID{
                get{
                    return this.GetColumn("EditID");
                }
            }
				
   			public static string EditIDColumn{
			      get{
        			return "EditID";
      			}
		    }
            
            public IColumn EditTime{
                get{
                    return this.GetColumn("EditTime");
                }
            }
				
   			public static string EditTimeColumn{
			      get{
        			return "EditTime";
      			}
		    }
            
            public IColumn DelID{
                get{
                    return this.GetColumn("DelID");
                }
            }
				
   			public static string DelIDColumn{
			      get{
        			return "DelID";
      			}
		    }
            
            public IColumn DelTime{
                get{
                    return this.GetColumn("DelTime");
                }
            }
				
   			public static string DelTimeColumn{
			      get{
        			return "DelTime";
      			}
		    }
            
            public IColumn tExamID{
                get{
                    return this.GetColumn("tExamID");
                }
            }
				
   			public static string tExamIDColumn{
			      get{
        			return "tExamID";
      			}
		    }
            
            public IColumn tKSID{
                get{
                    return this.GetColumn("tKSID");
                }
            }
				
   			public static string tKSIDColumn{
			      get{
        			return "tKSID";
      			}
		    }
            
            public IColumn inTime{
                get{
                    return this.GetColumn("inTime");
                }
            }
				
   			public static string inTimeColumn{
			      get{
        			return "inTime";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: WXDataCollections
        /// Primary Key: ID
        /// </summary>

        public class WXDataCollectionsTable: DatabaseTable {
            
            public WXDataCollectionsTable(IDataProvider provider):base("WXDataCollections",provider){
                ClassName = "WXDataCollection";
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

                Columns.Add(new DatabaseColumn("ksid", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("typeid", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("icount", this)
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
            
            public IColumn ksid{
                get{
                    return this.GetColumn("ksid");
                }
            }
				
   			public static string ksidColumn{
			      get{
        			return "ksid";
      			}
		    }
            
            public IColumn typeid{
                get{
                    return this.GetColumn("typeid");
                }
            }
				
   			public static string typeidColumn{
			      get{
        			return "typeid";
      			}
		    }
            
            public IColumn icount{
                get{
                    return this.GetColumn("icount");
                }
            }
				
   			public static string icountColumn{
			      get{
        			return "icount";
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
        /// Table: WXExamRules
        /// Primary Key: ID
        /// </summary>

        public class WXExamRulesTable: DatabaseTable {
            
            public WXExamRulesTable(IDataProvider provider):base("WXExamRules",provider){
                ClassName = "WXExamRule";
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

                Columns.Add(new DatabaseColumn("ExamGID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Guid,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("S_Sorts", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("RulesTitle", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 4000
                });

                Columns.Add(new DatabaseColumn("RulesScore", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("RulesScoreSet", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
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
            
            public IColumn ExamGID{
                get{
                    return this.GetColumn("ExamGID");
                }
            }
				
   			public static string ExamGIDColumn{
			      get{
        			return "ExamGID";
      			}
		    }
            
            public IColumn S_Sorts{
                get{
                    return this.GetColumn("S_Sorts");
                }
            }
				
   			public static string S_SortsColumn{
			      get{
        			return "S_Sorts";
      			}
		    }
            
            public IColumn RulesTitle{
                get{
                    return this.GetColumn("RulesTitle");
                }
            }
				
   			public static string RulesTitleColumn{
			      get{
        			return "RulesTitle";
      			}
		    }
            
            public IColumn RulesScore{
                get{
                    return this.GetColumn("RulesScore");
                }
            }
				
   			public static string RulesScoreColumn{
			      get{
        			return "RulesScore";
      			}
		    }
            
            public IColumn RulesScoreSet{
                get{
                    return this.GetColumn("RulesScoreSet");
                }
            }
				
   			public static string RulesScoreSetColumn{
			      get{
        			return "RulesScoreSet";
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

                Columns.Add(new DatabaseColumn("QGID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Guid,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ExamGID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Guid,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("RulesGID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Guid,
	                IsNullable = true,
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
	                MaxLength = 4000
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

                Columns.Add(new DatabaseColumn("Analysis", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 4000
                });

                Columns.Add(new DatabaseColumn("CreateID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("CreateTime", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("EditID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("EditTime", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("DelID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("DelTime", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ExamID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ReviewCount", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1000
                });

                Columns.Add(new DatabaseColumn("AnalyseNum", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1000
                });

                Columns.Add(new DatabaseColumn("isimg", this)
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
            
            public IColumn QGID{
                get{
                    return this.GetColumn("QGID");
                }
            }
				
   			public static string QGIDColumn{
			      get{
        			return "QGID";
      			}
		    }
            
            public IColumn ExamGID{
                get{
                    return this.GetColumn("ExamGID");
                }
            }
				
   			public static string ExamGIDColumn{
			      get{
        			return "ExamGID";
      			}
		    }
            
            public IColumn RulesGID{
                get{
                    return this.GetColumn("RulesGID");
                }
            }
				
   			public static string RulesGIDColumn{
			      get{
        			return "RulesGID";
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
            
            public IColumn Analysis{
                get{
                    return this.GetColumn("Analysis");
                }
            }
				
   			public static string AnalysisColumn{
			      get{
        			return "Analysis";
      			}
		    }
            
            public IColumn CreateID{
                get{
                    return this.GetColumn("CreateID");
                }
            }
				
   			public static string CreateIDColumn{
			      get{
        			return "CreateID";
      			}
		    }
            
            public IColumn CreateTime{
                get{
                    return this.GetColumn("CreateTime");
                }
            }
				
   			public static string CreateTimeColumn{
			      get{
        			return "CreateTime";
      			}
		    }
            
            public IColumn EditID{
                get{
                    return this.GetColumn("EditID");
                }
            }
				
   			public static string EditIDColumn{
			      get{
        			return "EditID";
      			}
		    }
            
            public IColumn EditTime{
                get{
                    return this.GetColumn("EditTime");
                }
            }
				
   			public static string EditTimeColumn{
			      get{
        			return "EditTime";
      			}
		    }
            
            public IColumn DelID{
                get{
                    return this.GetColumn("DelID");
                }
            }
				
   			public static string DelIDColumn{
			      get{
        			return "DelID";
      			}
		    }
            
            public IColumn DelTime{
                get{
                    return this.GetColumn("DelTime");
                }
            }
				
   			public static string DelTimeColumn{
			      get{
        			return "DelTime";
      			}
		    }
            
            public IColumn ExamID{
                get{
                    return this.GetColumn("ExamID");
                }
            }
				
   			public static string ExamIDColumn{
			      get{
        			return "ExamID";
      			}
		    }
            
            public IColumn ReviewCount{
                get{
                    return this.GetColumn("ReviewCount");
                }
            }
				
   			public static string ReviewCountColumn{
			      get{
        			return "ReviewCount";
      			}
		    }
            
            public IColumn AnalyseNum{
                get{
                    return this.GetColumn("AnalyseNum");
                }
            }
				
   			public static string AnalyseNumColumn{
			      get{
        			return "AnalyseNum";
      			}
		    }
            
            public IColumn isimg{
                get{
                    return this.GetColumn("isimg");
                }
            }
				
   			public static string isimgColumn{
			      get{
        			return "isimg";
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