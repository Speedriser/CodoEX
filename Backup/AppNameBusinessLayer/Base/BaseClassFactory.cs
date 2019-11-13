using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web.Configuration;

using CustName.AppName.DAL;

namespace CustName.AppName.BL
{
	public abstract class BaseClassFactory : IClassFactory
	{
		protected CustName.AppName.DAL.Repository repository = null;

		public virtual CustName.AppName.DAL.Repository GetDALRepository()
		{
			CustName.AppName.DAL.Repository repository1;
			if (CustName.AppName.BL.Settings.SingletonRepository)
			{
				if (this.repository == null)
					this.repository = GetNewDALRepository();
				repository1 = this.repository;
			}
			else
				repository1 = GetNewDALRepository();
			repository1.IgnoreCollision = CustName.AppName.BL.Settings.IgnoreCollision;
			return repository1;
		}

		public virtual CustName.AppName.BL.Repository GetRepository()
		{
			return new CustName.AppName.BL.Repository();
		}

		public virtual IEntityObject GetEntityObject(EntityClass entityClass)
		{
			return (IEntityObject)GetEntityObject(entityClass, Guid.NewGuid());
		}

		public virtual IEntityObject GetEntityObject(EntityClass entityClass, Guid instanceId)
		{
			if (entityClass == EntityClass.Attachment1)
				return (IEntityObject)(new Attachment1(instanceId));
			else if (entityClass == EntityClass.DependentEntity1)
				return (IEntityObject)(new DependentEntity1(instanceId));
			else if (entityClass == EntityClass.DependentEntity2)
				return (IEntityObject)(new DependentEntity2(instanceId));
			else if (entityClass == EntityClass.IndependentEntity1)
				return (IEntityObject)(new IndependentEntity1(instanceId));
			else if (entityClass == EntityClass.IndependentEntity2)
				return (IEntityObject)(new IndependentEntity2(instanceId));
			else if (entityClass == EntityClass.RelationshipEntity1)
				return (IEntityObject)(new RelationshipEntity1(instanceId));
			return null;
		}

		public virtual IEntityList GetEntityListObject(EntityClass entityClass)
		{
			if (entityClass == EntityClass.Attachment1)
				return (IEntityList)(new Attachment1List());
			else if (entityClass == EntityClass.DependentEntity1)
				return (IEntityList)(new DependentEntity1List());
			else if (entityClass == EntityClass.DependentEntity2)
				return (IEntityList)(new DependentEntity2List());
			else if (entityClass == EntityClass.IndependentEntity1)
				return (IEntityList)(new IndependentEntity1List());
			else if (entityClass == EntityClass.IndependentEntity2)
				return (IEntityList)(new IndependentEntity2List());
			else if (entityClass == EntityClass.RelationshipEntity1)
				return (IEntityList)(new RelationshipEntity1List());
			return null;
		}

		public virtual Type GetEntityType(EntityClass entityClass)
		{
			if (entityClass == EntityClass.Attachment1)
				return typeof(Attachment1);
			else if (entityClass == EntityClass.DependentEntity1)
				return typeof(DependentEntity1);
			else if (entityClass == EntityClass.DependentEntity2)
				return typeof(DependentEntity2);
			else if (entityClass == EntityClass.IndependentEntity1)
				return typeof(IndependentEntity1);
			else if (entityClass == EntityClass.IndependentEntity2)
				return typeof(IndependentEntity2);
			else if (entityClass == EntityClass.RelationshipEntity1)
				return typeof(RelationshipEntity1);
			return null;
		}

		public virtual Type GetEntityListType(EntityClass entityClass)
		{
			if (entityClass == EntityClass.Attachment1)
				return typeof(Attachment1List);
			else if (entityClass == EntityClass.DependentEntity1)
				return typeof(DependentEntity1List);
			else if (entityClass == EntityClass.DependentEntity2)
				return typeof(DependentEntity2List);
			else if (entityClass == EntityClass.IndependentEntity1)
				return typeof(IndependentEntity1List);
			else if (entityClass == EntityClass.IndependentEntity2)
				return typeof(IndependentEntity2List);
			else if (entityClass == EntityClass.RelationshipEntity1)
				return typeof(RelationshipEntity1List);
			return null;
		}

		protected CustName.AppName.DAL.Repository GetNewDALRepository()
		{
			ConnectionStringSettings connectionStringSettings;
			string commandTimeoutSetting;
			string connectionStringSetting;
			string userSetting;
			int? commandTimeout = null;
			if (CustName.AppName.BL.Settings.WebApplication)
			{
				if ((commandTimeoutSetting = WebConfigurationManager.AppSettings["CommandTimeout"]) != null)
					commandTimeout = Int32.Parse(commandTimeoutSetting);
				if ((connectionStringSettings = WebConfigurationManager.ConnectionStrings["AppNameDB"]) != null)
					connectionStringSetting = connectionStringSettings.ConnectionString;
				else
					connectionStringSetting = null;
				userSetting = WebConfigurationManager.AppSettings["User"];
			}
			else
			{
				if ((commandTimeoutSetting = ConfigurationManager.AppSettings["CommandTimeout"]) != null)
					commandTimeout = Int32.Parse(commandTimeoutSetting);
				if ((connectionStringSettings = ConfigurationManager.ConnectionStrings["AppNameDB"]) != null)
					connectionStringSetting = connectionStringSettings.ConnectionString;
				else
					connectionStringSetting = null;
				userSetting = ConfigurationManager.AppSettings["User"];
			}
			CustName.AppName.DAL.Repository repository = (CustName.AppName.DAL.Repository)(new SqlServerRepository((IClassFactory)this));
			if (commandTimeout.HasValue)
				repository.CommandTimeout = commandTimeout.Value;
			if (connectionStringSetting != null && connectionStringSetting.Length > 0)
				((SqlServerRepository)repository).ConnectionString = connectionStringSetting;
			if (userSetting != null)
				repository.User = userSetting;
			((SqlServerRepository)repository).MaintainOpenConnection = CustName.AppName.BL.Settings.MaintainOpenConnection;
			return repository;
		}
	}
}
