using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustName.AppName.BL
{
	public partial class Settings
	{
		// This method may be modified to alter the default values of the global DAL settings.
		// e.g. WebApplication = false;
		static Settings()
		{
			// CreateClassFactory
			// true:  Create an instance of CustName.AppName.BL.ClassFactory on application startup.
			// false: Do not an instance of CustName.AppName.BL.ClassFactory on application startup.
			//        The client application is responsible for setting CustName.AppName.BL.Global.ClassFactory to an instance of CustName.AppName.BL.ClassFactory or a class derived from CustName.AppName.BL.ClassFactory.
			//CreateClassFactory = true;
			// SingletonRepository
			// true:  Each call to CustName.AppName.BL.ClassFactory.GetDALRepository method returns the same CustName.AppName.DAL.Repository instance.
			//        Recommended for WinForms applications only.
			// false: Each call to CustName.AppName.BL.ClassFactory.GetDALRepository method returns a new CustName.AppName.DAL.Repository instance.
			//        Recommended for Web applications.
			//SingletonRepository = false;
			// WebApplication
			// true:  CustName.AppName.BL.ClassFactory to use System.Web.Configuration.WebConfigurationManager to read configuration settings.
			// false: CustName.AppName.BL.ClassFactory to use System.Configuration.ConfigurationManager to read configuration settings.
			//WebApplication = true;
			// IgnoreCollision
			// true:  CustName.AppName.DAL.Repository must not perform collision checks when updating the repository.
			// false: CustName.AppName.DAL.Repository must perform collision checks when updating the repository.
			//IgnoreCollision = false;
			// MaintainOpenConnection
			// Applicable to SQLServerRepository.
			// true:  CustName.AppName.DAL.Repository should maintain an open connection to the underlying DBMS until the Close() method is called or the Repository object is disposed.
			//        Recommended for web applications.
			// false: CustName.AppName.DAL.Repository should close the connection to the underlying DBMS after each SQL operation.
			//MaintainOpenConnection = false;

			// Recommended Web application settings:
			// CreateClassFactory = true
			// SingletonRepository = false
			// WebApplication = true
			// IgnoreCollision = false
			// MaintainOpenConnection = false

			// Recommended WinForms application settings:
			// CreateClassFactory = true
			// SingletonRepository = true
			// WebApplication = false
			// IgnoreCollision = false
			// MaintainOpenConnection = true if single user application, false otherwise.
		}
	}
}
