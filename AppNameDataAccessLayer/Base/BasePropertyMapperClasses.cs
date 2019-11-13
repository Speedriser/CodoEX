using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CustName.AppName.DAL
{
	public class BaseAttachment1BasePropertyNameMapper
	{
		public static string GetColumnName(Attachment1BasePropertyName propertyName)
		{
			string columnName = "";
			if (propertyName == Attachment1BasePropertyName.Attachment1Id)
				columnName = "attachment_1_id";
			else if (propertyName == Attachment1BasePropertyName.DependentEntity1Id)
				columnName = "dependent_entity_1_id";
			else if (propertyName == Attachment1BasePropertyName.AttachmentNotes)
				columnName = "attachment_notes";
			else if (propertyName == Attachment1BasePropertyName.AttachmentType)
				columnName = "attachment_type";
			else if (propertyName == Attachment1BasePropertyName.AttrBool1)
				columnName = "attr_bool_1";
			else if (propertyName == Attachment1BasePropertyName.AttrDatetime1)
				columnName = "attr_datetime_1";
			else if (propertyName == Attachment1BasePropertyName.AttrInteger1)
				columnName = "attr_integer_1";
			else if (propertyName == Attachment1BasePropertyName.AttrString1)
				columnName = "attr_string_1";
			else if (propertyName == Attachment1BasePropertyName.AttrString2)
				columnName = "attr_string_2";
			else if (propertyName == Attachment1BasePropertyName.FileAttachment)
				columnName = "file_attachment";
			else if (propertyName == Attachment1BasePropertyName.Name)
				columnName = "name";
			else if (propertyName == Attachment1BasePropertyName.Status)
				columnName = "status";
			else if (propertyName == Attachment1BasePropertyName.CreateTimestamp)
				columnName = "create_datetime";
			else if (propertyName == Attachment1BasePropertyName.CreateUser)
				columnName = "create_user";
			else if (propertyName == Attachment1BasePropertyName.LastUpdateTimestamp)
				columnName = "update_datetime";
			else if (propertyName == Attachment1BasePropertyName.LastUpdateUser)
				columnName = "update_user";
			else if (propertyName == Attachment1BasePropertyName.UpdateId)
				columnName = "update_id";
			return columnName;
		}

		public static DbType GetDbType(Attachment1BasePropertyName propertyName)
		{
			DbType dbType = DbType.Object;
			if (propertyName == Attachment1BasePropertyName.Attachment1Id)
				dbType = DbType.Int32;
			else if (propertyName == Attachment1BasePropertyName.DependentEntity1Id)
				dbType = DbType.Int32;
			else if (propertyName == Attachment1BasePropertyName.AttachmentNotes)
				dbType = DbType.String;
			else if (propertyName == Attachment1BasePropertyName.AttachmentType)
				dbType = DbType.String;
			else if (propertyName == Attachment1BasePropertyName.AttrBool1)
				dbType = DbType.Boolean;
			else if (propertyName == Attachment1BasePropertyName.AttrDatetime1)
				dbType = DbType.DateTime;
			else if (propertyName == Attachment1BasePropertyName.AttrInteger1)
				dbType = DbType.Int32;
			else if (propertyName == Attachment1BasePropertyName.AttrString1)
				dbType = DbType.String;
			else if (propertyName == Attachment1BasePropertyName.AttrString2)
				dbType = DbType.String;
			else if (propertyName == Attachment1BasePropertyName.FileAttachment)
				dbType = DbType.Binary;
			else if (propertyName == Attachment1BasePropertyName.Name)
				dbType = DbType.String;
			else if (propertyName == Attachment1BasePropertyName.Status)
				dbType = DbType.String;
			else if (propertyName == Attachment1BasePropertyName.CreateTimestamp)
				dbType = DbType.DateTime;
			else if (propertyName == Attachment1BasePropertyName.CreateUser)
				dbType = DbType.String;
			else if (propertyName == Attachment1BasePropertyName.LastUpdateTimestamp)
				dbType = DbType.DateTime;
			else if (propertyName == Attachment1BasePropertyName.LastUpdateUser)
				dbType = DbType.String;
			else if (propertyName == Attachment1BasePropertyName.UpdateId)
				dbType = DbType.Int32;
			return dbType;
		}
	}

	public class BaseDependentEntity1BasePropertyNameMapper
	{
		public static string GetColumnName(DependentEntity1BasePropertyName propertyName)
		{
			string columnName = "";
			if (propertyName == DependentEntity1BasePropertyName.DependentEntity1Id)
				columnName = "dependent_entity_1_id";
			else if (propertyName == DependentEntity1BasePropertyName.IndependentEntity1Id)
				columnName = "independent_entity_1_id";
			else if (propertyName == DependentEntity1BasePropertyName.AttrBool1)
				columnName = "attr_bool_1";
			else if (propertyName == DependentEntity1BasePropertyName.AttrDatetime1)
				columnName = "attr_datetime_1";
			else if (propertyName == DependentEntity1BasePropertyName.AttrInteger1)
				columnName = "attr_integer_1";
			else if (propertyName == DependentEntity1BasePropertyName.AttrString1)
				columnName = "attr_string_1";
			else if (propertyName == DependentEntity1BasePropertyName.AttrString2)
				columnName = "attr_string_2";
			else if (propertyName == DependentEntity1BasePropertyName.Name)
				columnName = "name";
			else if (propertyName == DependentEntity1BasePropertyName.Status)
				columnName = "status";
			else if (propertyName == DependentEntity1BasePropertyName.CreateTimestamp)
				columnName = "create_datetime";
			else if (propertyName == DependentEntity1BasePropertyName.CreateUser)
				columnName = "create_user";
			else if (propertyName == DependentEntity1BasePropertyName.LastUpdateTimestamp)
				columnName = "update_datetime";
			else if (propertyName == DependentEntity1BasePropertyName.LastUpdateUser)
				columnName = "update_user";
			else if (propertyName == DependentEntity1BasePropertyName.UpdateId)
				columnName = "update_id";
			return columnName;
		}

		public static DbType GetDbType(DependentEntity1BasePropertyName propertyName)
		{
			DbType dbType = DbType.Object;
			if (propertyName == DependentEntity1BasePropertyName.DependentEntity1Id)
				dbType = DbType.Int32;
			else if (propertyName == DependentEntity1BasePropertyName.IndependentEntity1Id)
				dbType = DbType.Int32;
			else if (propertyName == DependentEntity1BasePropertyName.AttrBool1)
				dbType = DbType.Boolean;
			else if (propertyName == DependentEntity1BasePropertyName.AttrDatetime1)
				dbType = DbType.DateTime;
			else if (propertyName == DependentEntity1BasePropertyName.AttrInteger1)
				dbType = DbType.Int32;
			else if (propertyName == DependentEntity1BasePropertyName.AttrString1)
				dbType = DbType.String;
			else if (propertyName == DependentEntity1BasePropertyName.AttrString2)
				dbType = DbType.String;
			else if (propertyName == DependentEntity1BasePropertyName.Name)
				dbType = DbType.String;
			else if (propertyName == DependentEntity1BasePropertyName.Status)
				dbType = DbType.String;
			else if (propertyName == DependentEntity1BasePropertyName.CreateTimestamp)
				dbType = DbType.DateTime;
			else if (propertyName == DependentEntity1BasePropertyName.CreateUser)
				dbType = DbType.String;
			else if (propertyName == DependentEntity1BasePropertyName.LastUpdateTimestamp)
				dbType = DbType.DateTime;
			else if (propertyName == DependentEntity1BasePropertyName.LastUpdateUser)
				dbType = DbType.String;
			else if (propertyName == DependentEntity1BasePropertyName.UpdateId)
				dbType = DbType.Int32;
			return dbType;
		}
	}

	public class BaseDependentEntity2BasePropertyNameMapper
	{
		public static string GetColumnName(DependentEntity2BasePropertyName propertyName)
		{
			string columnName = "";
			if (propertyName == DependentEntity2BasePropertyName.DependentEntity2Id)
				columnName = "dependent_entity_2_id";
			else if (propertyName == DependentEntity2BasePropertyName.DependentEntity1Id)
				columnName = "dependent_entity_1_id";
			else if (propertyName == DependentEntity2BasePropertyName.AttrBool1)
				columnName = "attr_bool_1";
			else if (propertyName == DependentEntity2BasePropertyName.AttrDatetime1)
				columnName = "attr_datetime_1";
			else if (propertyName == DependentEntity2BasePropertyName.AttrInteger1)
				columnName = "attr_integer_1";
			else if (propertyName == DependentEntity2BasePropertyName.AttrString1)
				columnName = "attr_string_1";
			else if (propertyName == DependentEntity2BasePropertyName.AttrString2)
				columnName = "attr_string_2";
			else if (propertyName == DependentEntity2BasePropertyName.Name)
				columnName = "name";
			else if (propertyName == DependentEntity2BasePropertyName.Status)
				columnName = "status";
			else if (propertyName == DependentEntity2BasePropertyName.CreateTimestamp)
				columnName = "create_datetime";
			else if (propertyName == DependentEntity2BasePropertyName.CreateUser)
				columnName = "create_user";
			else if (propertyName == DependentEntity2BasePropertyName.LastUpdateTimestamp)
				columnName = "update_datetime";
			else if (propertyName == DependentEntity2BasePropertyName.LastUpdateUser)
				columnName = "update_user";
			else if (propertyName == DependentEntity2BasePropertyName.UpdateId)
				columnName = "update_id";
			return columnName;
		}

		public static DbType GetDbType(DependentEntity2BasePropertyName propertyName)
		{
			DbType dbType = DbType.Object;
			if (propertyName == DependentEntity2BasePropertyName.DependentEntity2Id)
				dbType = DbType.Int32;
			else if (propertyName == DependentEntity2BasePropertyName.DependentEntity1Id)
				dbType = DbType.Int32;
			else if (propertyName == DependentEntity2BasePropertyName.AttrBool1)
				dbType = DbType.Boolean;
			else if (propertyName == DependentEntity2BasePropertyName.AttrDatetime1)
				dbType = DbType.DateTime;
			else if (propertyName == DependentEntity2BasePropertyName.AttrInteger1)
				dbType = DbType.Int32;
			else if (propertyName == DependentEntity2BasePropertyName.AttrString1)
				dbType = DbType.String;
			else if (propertyName == DependentEntity2BasePropertyName.AttrString2)
				dbType = DbType.String;
			else if (propertyName == DependentEntity2BasePropertyName.Name)
				dbType = DbType.String;
			else if (propertyName == DependentEntity2BasePropertyName.Status)
				dbType = DbType.String;
			else if (propertyName == DependentEntity2BasePropertyName.CreateTimestamp)
				dbType = DbType.DateTime;
			else if (propertyName == DependentEntity2BasePropertyName.CreateUser)
				dbType = DbType.String;
			else if (propertyName == DependentEntity2BasePropertyName.LastUpdateTimestamp)
				dbType = DbType.DateTime;
			else if (propertyName == DependentEntity2BasePropertyName.LastUpdateUser)
				dbType = DbType.String;
			else if (propertyName == DependentEntity2BasePropertyName.UpdateId)
				dbType = DbType.Int32;
			return dbType;
		}
	}

	public class BaseIndependentEntity1BasePropertyNameMapper
	{
		public static string GetColumnName(IndependentEntity1BasePropertyName propertyName)
		{
			string columnName = "";
			if (propertyName == IndependentEntity1BasePropertyName.IndependentEntity1Id)
				columnName = "independent_entity_1_id";
			else if (propertyName == IndependentEntity1BasePropertyName.AttrBool1)
				columnName = "attr_bool_1";
			else if (propertyName == IndependentEntity1BasePropertyName.AttrDatetime1)
				columnName = "attr_datetime_1";
			else if (propertyName == IndependentEntity1BasePropertyName.AttrInteger1)
				columnName = "attr_integer_1";
			else if (propertyName == IndependentEntity1BasePropertyName.AttrString1)
				columnName = "attr_string_1";
			else if (propertyName == IndependentEntity1BasePropertyName.AttrString2)
				columnName = "attr_string_2";
			else if (propertyName == IndependentEntity1BasePropertyName.Name)
				columnName = "name";
			else if (propertyName == IndependentEntity1BasePropertyName.Status)
				columnName = "status";
			else if (propertyName == IndependentEntity1BasePropertyName.CreateTimestamp)
				columnName = "create_datetime";
			else if (propertyName == IndependentEntity1BasePropertyName.CreateUser)
				columnName = "create_user";
			else if (propertyName == IndependentEntity1BasePropertyName.LastUpdateTimestamp)
				columnName = "update_datetime";
			else if (propertyName == IndependentEntity1BasePropertyName.LastUpdateUser)
				columnName = "update_user";
			else if (propertyName == IndependentEntity1BasePropertyName.UpdateId)
				columnName = "update_id";
			return columnName;
		}

		public static DbType GetDbType(IndependentEntity1BasePropertyName propertyName)
		{
			DbType dbType = DbType.Object;
			if (propertyName == IndependentEntity1BasePropertyName.IndependentEntity1Id)
				dbType = DbType.Int32;
			else if (propertyName == IndependentEntity1BasePropertyName.AttrBool1)
				dbType = DbType.Boolean;
			else if (propertyName == IndependentEntity1BasePropertyName.AttrDatetime1)
				dbType = DbType.DateTime;
			else if (propertyName == IndependentEntity1BasePropertyName.AttrInteger1)
				dbType = DbType.Int32;
			else if (propertyName == IndependentEntity1BasePropertyName.AttrString1)
				dbType = DbType.String;
			else if (propertyName == IndependentEntity1BasePropertyName.AttrString2)
				dbType = DbType.String;
			else if (propertyName == IndependentEntity1BasePropertyName.Name)
				dbType = DbType.String;
			else if (propertyName == IndependentEntity1BasePropertyName.Status)
				dbType = DbType.String;
			else if (propertyName == IndependentEntity1BasePropertyName.CreateTimestamp)
				dbType = DbType.DateTime;
			else if (propertyName == IndependentEntity1BasePropertyName.CreateUser)
				dbType = DbType.String;
			else if (propertyName == IndependentEntity1BasePropertyName.LastUpdateTimestamp)
				dbType = DbType.DateTime;
			else if (propertyName == IndependentEntity1BasePropertyName.LastUpdateUser)
				dbType = DbType.String;
			else if (propertyName == IndependentEntity1BasePropertyName.UpdateId)
				dbType = DbType.Int32;
			return dbType;
		}
	}

	public class BaseIndependentEntity2BasePropertyNameMapper
	{
		public static string GetColumnName(IndependentEntity2BasePropertyName propertyName)
		{
			string columnName = "";
			if (propertyName == IndependentEntity2BasePropertyName.IndependentEntity2Id)
				columnName = "independent_entity_2_id";
			else if (propertyName == IndependentEntity2BasePropertyName.AttrBool1)
				columnName = "attr_bool_1";
			else if (propertyName == IndependentEntity2BasePropertyName.AttrDatetime1)
				columnName = "attr_datetime_1";
			else if (propertyName == IndependentEntity2BasePropertyName.AttrInteger1)
				columnName = "attr_integer_1";
			else if (propertyName == IndependentEntity2BasePropertyName.AttrString1)
				columnName = "attr_string_1";
			else if (propertyName == IndependentEntity2BasePropertyName.AttrString2)
				columnName = "attr_string_2";
			else if (propertyName == IndependentEntity2BasePropertyName.Name)
				columnName = "name";
			else if (propertyName == IndependentEntity2BasePropertyName.Status)
				columnName = "status";
			else if (propertyName == IndependentEntity2BasePropertyName.CreateTimestamp)
				columnName = "create_datetime";
			else if (propertyName == IndependentEntity2BasePropertyName.CreateUser)
				columnName = "create_user";
			else if (propertyName == IndependentEntity2BasePropertyName.LastUpdateTimestamp)
				columnName = "update_datetime";
			else if (propertyName == IndependentEntity2BasePropertyName.LastUpdateUser)
				columnName = "update_user";
			else if (propertyName == IndependentEntity2BasePropertyName.UpdateId)
				columnName = "update_id";
			return columnName;
		}

		public static DbType GetDbType(IndependentEntity2BasePropertyName propertyName)
		{
			DbType dbType = DbType.Object;
			if (propertyName == IndependentEntity2BasePropertyName.IndependentEntity2Id)
				dbType = DbType.Int32;
			else if (propertyName == IndependentEntity2BasePropertyName.AttrBool1)
				dbType = DbType.Boolean;
			else if (propertyName == IndependentEntity2BasePropertyName.AttrDatetime1)
				dbType = DbType.DateTime;
			else if (propertyName == IndependentEntity2BasePropertyName.AttrInteger1)
				dbType = DbType.Int32;
			else if (propertyName == IndependentEntity2BasePropertyName.AttrString1)
				dbType = DbType.String;
			else if (propertyName == IndependentEntity2BasePropertyName.AttrString2)
				dbType = DbType.String;
			else if (propertyName == IndependentEntity2BasePropertyName.Name)
				dbType = DbType.String;
			else if (propertyName == IndependentEntity2BasePropertyName.Status)
				dbType = DbType.String;
			else if (propertyName == IndependentEntity2BasePropertyName.CreateTimestamp)
				dbType = DbType.DateTime;
			else if (propertyName == IndependentEntity2BasePropertyName.CreateUser)
				dbType = DbType.String;
			else if (propertyName == IndependentEntity2BasePropertyName.LastUpdateTimestamp)
				dbType = DbType.DateTime;
			else if (propertyName == IndependentEntity2BasePropertyName.LastUpdateUser)
				dbType = DbType.String;
			else if (propertyName == IndependentEntity2BasePropertyName.UpdateId)
				dbType = DbType.Int32;
			return dbType;
		}
	}

	public class BaseRelationshipEntity1BasePropertyNameMapper
	{
		public static string GetColumnName(RelationshipEntity1BasePropertyName propertyName)
		{
			string columnName = "";
			if (propertyName == RelationshipEntity1BasePropertyName.RelationshipEntity1Id)
				columnName = "relationship_entity_1_id";
			else if (propertyName == RelationshipEntity1BasePropertyName.DependentEntity2Id)
				columnName = "dependent_entity_2_id";
			else if (propertyName == RelationshipEntity1BasePropertyName.IndependentEntity2Id)
				columnName = "independent_entity_2_id";
			else if (propertyName == RelationshipEntity1BasePropertyName.AttrBool1)
				columnName = "attr_bool_1";
			else if (propertyName == RelationshipEntity1BasePropertyName.AttrDatetime1)
				columnName = "attr_datetime_1";
			else if (propertyName == RelationshipEntity1BasePropertyName.AttrInteger1)
				columnName = "attr_integer_1";
			else if (propertyName == RelationshipEntity1BasePropertyName.AttrString1)
				columnName = "attr_string_1";
			else if (propertyName == RelationshipEntity1BasePropertyName.AttrString2)
				columnName = "attr_string_2";
			else if (propertyName == RelationshipEntity1BasePropertyName.Name)
				columnName = "name";
			else if (propertyName == RelationshipEntity1BasePropertyName.Status)
				columnName = "status";
			else if (propertyName == RelationshipEntity1BasePropertyName.CreateTimestamp)
				columnName = "create_datetime";
			else if (propertyName == RelationshipEntity1BasePropertyName.CreateUser)
				columnName = "create_user";
			else if (propertyName == RelationshipEntity1BasePropertyName.LastUpdateTimestamp)
				columnName = "update_datetime";
			else if (propertyName == RelationshipEntity1BasePropertyName.LastUpdateUser)
				columnName = "update_user";
			else if (propertyName == RelationshipEntity1BasePropertyName.UpdateId)
				columnName = "update_id";
			return columnName;
		}

		public static DbType GetDbType(RelationshipEntity1BasePropertyName propertyName)
		{
			DbType dbType = DbType.Object;
			if (propertyName == RelationshipEntity1BasePropertyName.RelationshipEntity1Id)
				dbType = DbType.Int32;
			else if (propertyName == RelationshipEntity1BasePropertyName.DependentEntity2Id)
				dbType = DbType.Int32;
			else if (propertyName == RelationshipEntity1BasePropertyName.IndependentEntity2Id)
				dbType = DbType.Int32;
			else if (propertyName == RelationshipEntity1BasePropertyName.AttrBool1)
				dbType = DbType.Boolean;
			else if (propertyName == RelationshipEntity1BasePropertyName.AttrDatetime1)
				dbType = DbType.DateTime;
			else if (propertyName == RelationshipEntity1BasePropertyName.AttrInteger1)
				dbType = DbType.Int32;
			else if (propertyName == RelationshipEntity1BasePropertyName.AttrString1)
				dbType = DbType.String;
			else if (propertyName == RelationshipEntity1BasePropertyName.AttrString2)
				dbType = DbType.String;
			else if (propertyName == RelationshipEntity1BasePropertyName.Name)
				dbType = DbType.String;
			else if (propertyName == RelationshipEntity1BasePropertyName.Status)
				dbType = DbType.String;
			else if (propertyName == RelationshipEntity1BasePropertyName.CreateTimestamp)
				dbType = DbType.DateTime;
			else if (propertyName == RelationshipEntity1BasePropertyName.CreateUser)
				dbType = DbType.String;
			else if (propertyName == RelationshipEntity1BasePropertyName.LastUpdateTimestamp)
				dbType = DbType.DateTime;
			else if (propertyName == RelationshipEntity1BasePropertyName.LastUpdateUser)
				dbType = DbType.String;
			else if (propertyName == RelationshipEntity1BasePropertyName.UpdateId)
				dbType = DbType.Int32;
			return dbType;
		}
	}
}
