using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CustName.AppName.DAL
{
	public abstract class BaseSqlServerRepository : Repository, IDisposable
	{
		// Track whether Dispose has been called.
		private bool disposed = false;
		private SqlConnection connection;
		private bool maintainOpenConnection;

		#region Attachment1 related private variables.

		protected SqlCommand attachment1GetCmd;
		protected SqlCommand attachment1GetBLOBCmd;
		protected SqlCommand attachment1InsertCmd;
		protected SqlCommand attachment1DeleteCmd;
		protected SqlCommand attachment1UpdateCmd;
		private SortSpecification attachment1SortSpecification;

		#endregion Attachment1 related private variables.

		#region DependentEntity1 related private variables.

		protected SqlCommand dependentEntity1GetCmd;
		protected SqlCommand dependentEntity1GetBLOBCmd;
		protected SqlCommand dependentEntity1InsertCmd;
		protected SqlCommand dependentEntity1DeleteCmd;
		protected SqlCommand dependentEntity1UpdateCmd;
		private SortSpecification dependentEntity1SortSpecification;
		private SortSpecification dependentEntity1_ChildOwnedAttachment1SortSpecification;
		private SortSpecification dependentEntity1_ChildOwnedDependentEntity2SortSpecification;

		#endregion DependentEntity1 related private variables.

		#region DependentEntity2 related private variables.

		protected SqlCommand dependentEntity2GetCmd;
		protected SqlCommand dependentEntity2GetBLOBCmd;
		protected SqlCommand dependentEntity2InsertCmd;
		protected SqlCommand dependentEntity2DeleteCmd;
		protected SqlCommand dependentEntity2UpdateCmd;
		private SortSpecification dependentEntity2SortSpecification;
		private SortSpecification dependentEntity2_ChildOwnedRelationshipEntity1SortSpecification;

		#endregion DependentEntity2 related private variables.

		#region IndependentEntity1 related private variables.

		protected SqlCommand independentEntity1GetCmd;
		protected SqlCommand independentEntity1GetBLOBCmd;
		protected SqlCommand independentEntity1InsertCmd;
		protected SqlCommand independentEntity1DeleteCmd;
		protected SqlCommand independentEntity1UpdateCmd;
		private SortSpecification independentEntity1SortSpecification;
		private SortSpecification independentEntity1_ChildOwnedDependentEntity1SortSpecification;

		#endregion IndependentEntity1 related private variables.

		#region IndependentEntity2 related private variables.

		protected SqlCommand independentEntity2GetCmd;
		protected SqlCommand independentEntity2GetBLOBCmd;
		protected SqlCommand independentEntity2InsertCmd;
		protected SqlCommand independentEntity2DeleteCmd;
		protected SqlCommand independentEntity2UpdateCmd;
		private SortSpecification independentEntity2SortSpecification;
		private SortSpecification independentEntity2_ChildOwnedRelationshipEntity1SortSpecification;

		#endregion IndependentEntity2 related private variables.

		#region RelationshipEntity1 related private variables.

		protected SqlCommand relationshipEntity1GetCmd;
		protected SqlCommand relationshipEntity1GetBLOBCmd;
		protected SqlCommand relationshipEntity1InsertCmd;
		protected SqlCommand relationshipEntity1DeleteCmd;
		protected SqlCommand relationshipEntity1UpdateCmd;
		private SortSpecification relationshipEntity1SortSpecification;

		#endregion RelationshipEntity1 related private variables.

		public BaseSqlServerRepository(IClassFactory classFactory)
		{
			this.classFactory = classFactory;
			this.connection = new SqlConnection();
			this.attachment1SortSpecification = this.Attachment1DefaultSortSpecification;
			this.dependentEntity1SortSpecification = this.DependentEntity1DefaultSortSpecification;
			this.dependentEntity1_ChildOwnedAttachment1SortSpecification = this.DependentEntity1_ChildOwnedAttachment1DefaultSortSpecification;
			this.dependentEntity1_ChildOwnedDependentEntity2SortSpecification = this.DependentEntity1_ChildOwnedDependentEntity2DefaultSortSpecification;
			this.dependentEntity2SortSpecification = this.DependentEntity2DefaultSortSpecification;
			this.dependentEntity2_ChildOwnedRelationshipEntity1SortSpecification = this.DependentEntity2_ChildOwnedRelationshipEntity1DefaultSortSpecification;
			this.independentEntity1SortSpecification = this.IndependentEntity1DefaultSortSpecification;
			this.independentEntity1_ChildOwnedDependentEntity1SortSpecification = this.IndependentEntity1_ChildOwnedDependentEntity1DefaultSortSpecification;
			this.independentEntity2SortSpecification = this.IndependentEntity2DefaultSortSpecification;
			this.independentEntity2_ChildOwnedRelationshipEntity1SortSpecification = this.IndependentEntity2_ChildOwnedRelationshipEntity1DefaultSortSpecification;
			this.relationshipEntity1SortSpecification = this.RelationshipEntity1DefaultSortSpecification;
		}

		// This destructor will run only if the Dispose method does not get called.
		// Do not provide destructors in types derived from this class.
		~BaseSqlServerRepository()
		{
			Dispose(false);
		}

		public void Dispose()
		{
			Dispose(true);
			// Take object off the Finalization queue to prevent finalization code for this object from executing a second time.
			GC.SuppressFinalize(this);
		}

		// Dispose(bool disposing) executes in two distinct scenarios.
		// If disposing equals true, the method has been called directly or indirectly by a user's code.
		// Managed and unmanaged resources can be disposed.
		// If disposing equals false, the method has been called by the runtime from inside the finalizer and should not reference other objects.
		// Only unmanaged resources can be disposed.
		protected virtual void Dispose(bool disposing)
		{
			// Check to see if Dispose has already been called.
			if (!this.disposed)
			{
				// If disposing equals true, dispose all managed and unmanaged resources, otherwise only unmanaged resources.
				if (disposing)
				{
					// Dispose managed resources.
					this.connection.Close();
				}
				// Release unmanaged resources.
				// If disposing is false, only the following code is executed.

				// Note that this is not thread safe.
				// Another thread could start disposing the object after the managed resources are disposed, but before the disposed flag is set to true.
				// If thread safety is necessary, it must be implemented by the client.
				disposed = true;
			}
		}

		public override void Close()
		{
			Dispose();
		}

		#region Connection related members.

		public SqlConnection Connection
		{
			get
			{
				return this.connection;
			}
		}

		public virtual string ConnectionString
		{
			get
			{
				return this.connection.ConnectionString;
			}
			set
			{
				if (value != this.connection.ConnectionString)
					this.connection.ConnectionString = value; // Will raise exception if connection not closed.
			}
		}

		public bool MaintainOpenConnection
		{
			get
			{
				return this.maintainOpenConnection;
			}
			set
			{
				this.maintainOpenConnection = value;
			}
		}

		public virtual void BeforeCommandExecute()
		{
			if (this.connection.State == ConnectionState.Closed)
			{
				this.connection.Open();
			}
			else if (this.connection.State == ConnectionState.Broken)
			{
				try
				{
					this.connection.Close();
				}
				catch (SqlException)
				{
					this.connection = new SqlConnection();
				}
				this.connection.Open();
			}
		}

		public virtual void AfterCommandExecute()
		{
			if (!this.maintainOpenConnection)
			{
				try
				{
					this.connection.Close();
				}
				catch (SqlException) { }
			}
		}

		private void ResetCache()
		{
			#region Attachment1 related.

			this.attachment1GetCmd = null;
			this.attachment1GetBLOBCmd = null;
			this.attachment1InsertCmd = null;
			this.attachment1UpdateCmd = null;

			#endregion Attachment1 related.

			#region DependentEntity1 related.

			this.dependentEntity1GetCmd = null;
			this.dependentEntity1GetBLOBCmd = null;
			this.dependentEntity1InsertCmd = null;
			this.dependentEntity1UpdateCmd = null;

			#endregion DependentEntity1 related.

			#region DependentEntity2 related.

			this.dependentEntity2GetCmd = null;
			this.dependentEntity2GetBLOBCmd = null;
			this.dependentEntity2InsertCmd = null;
			this.dependentEntity2UpdateCmd = null;

			#endregion DependentEntity2 related.

			#region IndependentEntity1 related.

			this.independentEntity1GetCmd = null;
			this.independentEntity1GetBLOBCmd = null;
			this.independentEntity1InsertCmd = null;
			this.independentEntity1UpdateCmd = null;

			#endregion IndependentEntity1 related.

			#region IndependentEntity2 related.

			this.independentEntity2GetCmd = null;
			this.independentEntity2GetBLOBCmd = null;
			this.independentEntity2InsertCmd = null;
			this.independentEntity2UpdateCmd = null;

			#endregion IndependentEntity2 related.

			#region RelationshipEntity1 related.

			this.relationshipEntity1GetCmd = null;
			this.relationshipEntity1GetBLOBCmd = null;
			this.relationshipEntity1InsertCmd = null;
			this.relationshipEntity1UpdateCmd = null;

			#endregion RelationshipEntity1 related.
		}

		#endregion Connection related members.

		#region Attachment1 related members.

		public override IAttachment1List FindAttachment1(int maxCount, SearchCondition searchCondition)
		{
			return this.FindAttachment1(maxCount, searchCondition, null, null);
		}

		public override IAttachment1List FindAttachment1(int maxCount, SearchCondition searchCondition, SortSpecification sortSpecification)
		{
			return this.FindAttachment1(maxCount, searchCondition, sortSpecification, null);
		}

		public override IAttachment1List FindAttachment1(int maxCount, SearchCondition searchCondition, IEntityObjectContext context)
		{
			return this.FindAttachment1(maxCount, searchCondition, null, context);
		}

		public override IAttachment1List FindAttachment1(int maxCount, SearchCondition searchCondition, SortSpecification sortSpecification, IEntityObjectContext context)
		{
			try
			{
				string sql = "SELECT ";
				if (maxCount > -1) sql += "TOP " + maxCount.ToString("d") + " ";
				sql +=
				"[attachment_1_id]," +
				"[dependent_entity_1_id]," +
				"[attachment_notes]," +
				"[attachment_type]," +
				"[attr_bool_1]," +
				"[attr_datetime_1]," +
				"[attr_integer_1]," +
				"[attr_string_1]," +
				"[attr_string_2]," +
				"(CAST((CASE WHEN ([file_attachment] IS NULL) THEN 1 ELSE 0 END) AS BIT)) AS [file_attachment_is_null]," +
				"[file_name]," +
				"[name]," +
				"[status]," +
				"[create_datetime]," +
				"[create_user]," +
				"[update_datetime]," +
				"[update_id]," +
				"[update_user]" +
				" FROM [attachment_1]";
				SqlCommand cmd = new SqlCommand();
				cmd.CommandTimeout = this.commandTimeout;
				cmd.Connection = this.connection;
				//
				// Add SQL Where criteria if required.
				//
				string whereClause;
				ArrayList whereClauseParameters;
				BuildWhereClause(searchCondition, out whereClause, out whereClauseParameters);
				if (whereClause != null && whereClause != "")
				{
					sql = sql + " WHERE " + whereClause;
					foreach (SqlParameter param in whereClauseParameters)
					{
						cmd.Parameters.Add(param);
					}
				}
				//
				// Add SQL ORDER BY clause if required.
				//
				string orderByClause;
				if (sortSpecification == null)
					orderByClause = BuildOrderByClause(this.attachment1SortSpecification);
				else
					orderByClause = BuildOrderByClause(sortSpecification);
				if (orderByClause != null && orderByClause != "")
					sql += " ORDER BY " + orderByClause;
				//
				// Execute SQL Select command and convert results into a list of Attachment1 objects.
				//
				cmd.CommandText = sql;
				cmd.CommandType = CommandType.Text;
				BeforeCommandExecute();
				SqlDataReader sdr = cmd.ExecuteReader();
				IAttachment1List attachment1List = (IAttachment1List)this.classFactory.GetEntityListObject(EntityClass.Attachment1);
				if (sdr.HasRows)
				{
					if (context == null)
					{
						while (sdr.Read())
						{
							attachment1List.Add(CreateAttachment1FromSqlDataReader(sdr));
						}
					}
					else
					{
						Attachment1Identifier? identifier;
						IEntityObjectContextItem obj;
						while (sdr.Read())
						{
							// Get the primary object id.
							identifier = CreateAttachment1IdentifierFromSqlDataReader(sdr, 0);
							if (identifier == null)
							{
								attachment1List.Add(CreateAttachment1FromSqlDataReader(sdr));
							}
							else
							{
								if ((obj = context.Get((IIdentifier)identifier.Value)) == null)
									attachment1List.Add(CreateAttachment1FromSqlDataReader(sdr));
								else
									attachment1List.Add(obj);
							}
						}
					}
				}
				sdr.Close();

				return attachment1List;
			}
			catch (SqlException e)
			{
				throw new DALException(RepositoryExceptionMessage.UnexpectedExceptionDetected, e);
			}
			finally
			{
				AfterCommandExecute();
			}
		}

		// Parameter propertyName must be a Attachment1PropertyName class constant (Attachment1BasePropertyName is a subset of Attachment1PropertyName).
		public override ArrayList GetAssociatedAttachment1Ids(int maxCount, Attachment1PropertyName propertyName, object value)
		{
			try
			{
				// Create SQL command.

				string sql = "SELECT ";
				if (maxCount > -1) sql += "TOP " + maxCount.ToString("d") + " ";
				sql +=
				"[attachment_1_id] " +
				"FROM [attachment_1]";

				// Add Where condition.

				SearchCondition searchCondition = new SearchCondition().AppendSearchCondition(propertyName, SearchConditionExpressionOperator.Equal, value);
				string whereClause;
				ArrayList whereClauseParameters;
				BuildWhereClause(searchCondition, out whereClause, out whereClauseParameters);
				sql = sql + " WHERE " + whereClause;
				SqlCommand cmd = new SqlCommand(sql, this.connection);
				cmd.CommandTimeout = this.commandTimeout;
				cmd.CommandType = CommandType.Text;
				foreach (SqlParameter param in whereClauseParameters)
					cmd.Parameters.Add(param);

				// Execute query.

				BeforeCommandExecute();
				SqlDataReader sdr = cmd.ExecuteReader();
				ArrayList attachment1IdentifierList = new ArrayList();
				if (sdr.HasRows)
				{
					while (sdr.Read())
						attachment1IdentifierList.Add(CreateAttachment1IdentifierFromSqlDataReader(sdr, 0));
				}
				sdr.Close();

				return attachment1IdentifierList;
			}
			catch (SqlException e)
			{
				throw new DALException(RepositoryExceptionMessage.UnexpectedExceptionDetected, e);
			}
			finally
			{
				AfterCommandExecute();
			}
		}

		public SortSpecification Attachment1SortSpecification
		{
			get
			{
				return this.attachment1SortSpecification;
			}
			set
			{
				this.attachment1SortSpecification = value;
			}
		}

		public virtual SortSpecification Attachment1DefaultSortSpecification
		{
			get
			{
				return null;
			}
		}

		protected override void DeleteAttachment1(SearchCondition searchCondition)
		{
			// To avoid accidental deletion of all Attachment1 objects, insist on a search condition.
			bool haveSearchCondition;
			if (searchCondition == null)
				haveSearchCondition = false;
			else
				haveSearchCondition = (!searchCondition.IsNullCondition());
			if (!haveSearchCondition) throw new DALException(RepositoryExceptionMessage.NonEmptySearchConditionRequired);

			try
			{
				SqlCommand cmd = new SqlCommand();
				cmd.CommandTimeout = this.commandTimeout;
				cmd.Connection = this.connection;
				string sql = "DELETE FROM [attachment_1]";
				//
				// Add SQL Where criteria if required.
				//
				string sqlWhereConditionText;
				ArrayList sqlWhereConditionParameters;
				BuildWhereClause(searchCondition, out sqlWhereConditionText, out sqlWhereConditionParameters);
				if (sqlWhereConditionText != null && sqlWhereConditionText != "")
				{
					sql = sql + " WHERE " + sqlWhereConditionText;
					foreach (SqlParameter param in sqlWhereConditionParameters)
					{
						cmd.Parameters.Add(param);
					}
				}
				cmd.CommandText = sql;
				cmd.CommandType = CommandType.Text;
				//
				// Execute SQL Delete command.
				//
				BeforeCommandExecute();
				cmd.ExecuteNonQuery();
			}
			catch (SqlException e)
			{
				throw new DALException(RepositoryExceptionMessage.UnexpectedExceptionDetected, e);
			}
			finally
			{
				AfterCommandExecute();
			}
		}


		public override IAttachment1 GetAttachment1(Attachment1Identifier objectId)
		{
			return this.GetAttachment1(objectId, null);
		}

		public override IAttachment1 GetAttachment1(Attachment1Identifier objectId, IEntityObjectContext context)
		{
			try
			{
				IAttachment1 attachment1 = null;

				if (context == null || (context != null && (attachment1 = (IAttachment1)context.Get((IIdentifier)objectId)) == null))
				{
					if (this.attachment1GetCmd == null) CreateAttachment1GetCommand();
					SqlCommand cmd = this.attachment1GetCmd;

					// Set input parameters.
					cmd.Parameters["@p_attachment_1_id"].Value = objectId.Attachment1Id;

					// Call stored procedure.
					BeforeCommandExecute();
					cmd.ExecuteNonQuery();

					// Process results.

					if ((int)cmd.Parameters["@p_rc_"].Value == 1)
					{
						// Object retrieved successfully.

						attachment1 = (IAttachment1)this.classFactory.GetEntityObject(EntityClass.Attachment1);
						attachment1.ObjectId = objectId;
						bool foundNullValue;
						// Process foreign key fields associated with the DependentEntity1 owner relationship.
						foundNullValue = (cmd.Parameters["@p_dependent_entity_1_id"].Value == DBNull.Value);
						if (foundNullValue)
						{
							attachment1.ParentOwnerDependentEntity1EntityObjectId = null;
						}
						else
						{
							DependentEntity1Identifier identifier0 = new DependentEntity1Identifier();
							identifier0.DependentEntity1Id = (int)cmd.Parameters["@p_dependent_entity_1_id"].Value;
							attachment1.ParentOwnerDependentEntity1EntityObjectId = identifier0;
						}
						// [attachment_notes]
						if (cmd.Parameters["@p_attachment_notes"].Value == DBNull.Value)
						{
							attachment1.AttachmentNotes = null;
						}
						else
						{
							attachment1.AttachmentNotes = (string)cmd.Parameters["@p_attachment_notes"].Value;
						}
						// [attachment_type]
						if (cmd.Parameters["@p_attachment_type"].Value == DBNull.Value)
						{
							attachment1.AttachmentType = null;
						}
						else
						{
							attachment1.AttachmentType = (string)cmd.Parameters["@p_attachment_type"].Value;
						}
						// [attr_bool_1]
						if (cmd.Parameters["@p_attr_bool_1"].Value == DBNull.Value)
						{
							attachment1.AttrBool1 = null;
						}
						else
						{
							attachment1.AttrBool1 = (bool)cmd.Parameters["@p_attr_bool_1"].Value;
						}
						// [attr_datetime_1]
						if (cmd.Parameters["@p_attr_datetime_1"].Value == DBNull.Value)
						{
							attachment1.AttrDatetime1 = null;
						}
						else
						{
							attachment1.AttrDatetime1 = (DateTime)cmd.Parameters["@p_attr_datetime_1"].Value;
						}
						// [attr_integer_1]
						if (cmd.Parameters["@p_attr_integer_1"].Value == DBNull.Value)
						{
							attachment1.AttrInteger1 = null;
						}
						else
						{
							attachment1.AttrInteger1 = (int)cmd.Parameters["@p_attr_integer_1"].Value;
						}
						// [attr_string_1]
						if (cmd.Parameters["@p_attr_string_1"].Value == DBNull.Value)
						{
							attachment1.AttrString1 = null;
						}
						else
						{
							attachment1.AttrString1 = (string)cmd.Parameters["@p_attr_string_1"].Value;
						}
						// [attr_string_2]
						if (cmd.Parameters["@p_attr_string_2"].Value == DBNull.Value)
						{
							attachment1.AttrString2 = null;
						}
						else
						{
							attachment1.AttrString2 = (string)cmd.Parameters["@p_attr_string_2"].Value;
						}
						// [file_attachment]
						if ((bool)cmd.Parameters["@p_file_attachment_is_null"].Value)
							attachment1.FileAttachment = null;
						else
							attachment1.FileAttachment = new FileAttachment((string)cmd.Parameters["@p_file_name"].Value, new PropertyLoad(attachment1.FileAttachment_Load));
						// [name]
						if (cmd.Parameters["@p_name"].Value == DBNull.Value)
						{
							attachment1.Name = null;
						}
						else
						{
							attachment1.Name = (string)cmd.Parameters["@p_name"].Value;
						}
						// [status]
						if (cmd.Parameters["@p_status"].Value == DBNull.Value)
						{
							attachment1.Status = null;
						}
						else
						{
							attachment1.Status = (string)cmd.Parameters["@p_status"].Value;
						}
						// [create_datetime]
						if (cmd.Parameters["@p_create_datetime"].Value == DBNull.Value)
							attachment1.CreateTimestamp = null;
						else
							attachment1.CreateTimestamp = (DateTime)cmd.Parameters["@p_create_datetime"].Value;
						// [create_user]
						if (cmd.Parameters["@p_create_user"].Value == DBNull.Value)
							attachment1.CreateUser = null;
						else
							attachment1.CreateUser = (string)cmd.Parameters["@p_create_user"].Value;
						// [update_datetime]
						if (cmd.Parameters["@p_update_datetime"].Value == DBNull.Value)
							attachment1.LastUpdateTimestamp = null;
						else
							attachment1.LastUpdateTimestamp = (DateTime)cmd.Parameters["@p_update_datetime"].Value;
						// [update_id]
						if (cmd.Parameters["@p_update_id"].Value == DBNull.Value)
							attachment1.UpdateId = 0;
						else
							attachment1.UpdateId = (int)cmd.Parameters["@p_update_id"].Value;
						// [update_user]
						if (cmd.Parameters["@p_update_user"].Value == DBNull.Value)
							attachment1.LastUpdateUser = null;
						else
							attachment1.LastUpdateUser = (string)cmd.Parameters["@p_update_user"].Value;
						attachment1.ObjectStatus = ObjectStatus.Existing;
						attachment1.HasUncommittedChanges = false;
					}

					// Add newly loaded object to context.
					if (context != null)
						context.Add((IEntityObjectContextItem)attachment1);
				}

				return this.OnAttachment1Load(attachment1);
			}
			catch (SqlException e)
			{
				throw new DALException(RepositoryExceptionMessage.UnexpectedExceptionDetected, e);
			}
			finally
			{
				AfterCommandExecute();
			}
		}

		public override byte[] GetAttachment1BLOB(Attachment1Identifier objectId, int updateId, string columnName)
		{
			return GetAttachment1BLOBCore(objectId, updateId, columnName, this.ignoreCollision);
		}

		public override byte[] GetAttachment1BLOB(Attachment1Identifier objectId, int updateId, string columnName, bool ignoreCollision)
		{
			return GetAttachment1BLOBCore(objectId, updateId, columnName, ignoreCollision);
		}

		protected override byte[] GetAttachment1BLOBCore(Attachment1Identifier objectId, int updateId, string columnName, bool ignoreCollision)
		{
			try
			{
				if (this.attachment1GetBLOBCmd == null)
					CreateAttachment1GetBLOBCommand();
				SqlCommand cmd = this.attachment1GetBLOBCmd;

				// Set input parameters.

				cmd.Parameters["@p_attachment_1_id"].Value = objectId.Attachment1Id;
				if (ignoreCollision)
					cmd.Parameters["@p_ignore_collision_"].Value = 1;
				else
					cmd.Parameters["@p_ignore_collision_"].Value = 0;
				cmd.Parameters["@p_update_id_"].Value = updateId;
				cmd.Parameters["@p_column_name_"].Value = columnName;

				// Call stored procedure.
				BeforeCommandExecute();
				cmd.ExecuteNonQuery();

				// Process results.

				switch ((int)cmd.Parameters["@p_rc_"].Value)
				{
					case 1: // Fetch successful.
						if (cmd.Parameters["@p_blob_"].Value == DBNull.Value)
							return null;
						else
							return (byte[])cmd.Parameters["@p_blob_"].Value;
					case 2: // Collision - object updated by another user.
						throw new SingleCollisionException(RepositoryExceptionMessage.UpdateCollisionDetected, EntityClass.Attachment1, objectId, CollisionType.Update, (string)cmd.Parameters["@p_user_"].Value, (DateTime)cmd.Parameters["@p_update_ts_"].Value);
					case 3: // Collision - object physically deleted by another user.
						throw new SingleCollisionException(RepositoryExceptionMessage.DeleteCollisionDetected, EntityClass.Attachment1, objectId, CollisionType.Delete, null, DateTime.MinValue);
					default:
						return null;
				}
			}
			catch (SqlException e)
			{
				throw new DALException(RepositoryExceptionMessage.UnexpectedExceptionDetected, e);
			}
			finally
			{
				AfterCommandExecute();
			}
		}


		public override void DeleteAttachment1(IAttachment1 attachment1)
		{
			DeleteAttachment1Core(attachment1, this.ignoreCollision);
		}

		public override void DeleteAttachment1(IAttachment1 attachment1, bool ignoreCollision)
		{
			DeleteAttachment1Core(attachment1, ignoreCollision);
		}

		protected override void DeleteAttachment1Core(IAttachment1 attachment1, bool ignoreCollision)
		{
			// When transaction support is added, ApplySaveLog must not be called if an exception is encountered.
			SaveLog saveLog = new SaveLog();
			try
			{
				DeleteAttachment1Core(attachment1, ignoreCollision, saveLog);
				saveLog.ApplySaveLog();
			}
			catch (Exception)
			{
				// Still call ApplySaveLog because no support for transaction/rollback yet.
				saveLog.ApplySaveLog();
				throw;
			}
		}

		// Because cascade delete operations are handled at the DB level, this implementation of this function is trivial.
		protected override void DeleteAttachment1Core(IAttachment1 attachment1, bool ignoreCollision, SaveLog saveLog)
		{
			DeleteAttachment1EntityObjectCore(attachment1, ignoreCollision, saveLog);
		}

		protected override void DeleteAttachment1EntityObjectCore(IAttachment1 attachment1, bool ignoreCollision, SaveLog saveLog)
		{
			SaveLogEntry saveLogEntry = new SaveLogEntry();
			// These saveLogEntry assignments must occur here so that they are set if an exception occurs.
			saveLogEntry.EntityObject = attachment1;
			saveLogEntry.PreSaveObjectStatus = attachment1.ObjectStatus;
			try
			{
				saveLogEntry.RepositoryUpdateOperation = RepositoryUpdateOperation.Delete;

				DeleteAttachment1((Attachment1Identifier)attachment1.ObjectId, attachment1.UpdateId, ignoreCollision);

				saveLogEntry.PostSaveObjectStatus = ObjectStatus.Deleted;
				saveLog.Add(saveLogEntry);
				// Add SaveLog entries for in-memory objects owned by attachment1 that must have been cascade deleted by the repository.
				saveLog.UpdateSaveLogForCascadeDelete((IEntityObject)attachment1);
			}
			catch (SingleCollisionException e)
			{
				// Update the object's status to reflect the collision.
				if (e.Collision.CollisionType == CollisionType.Delete)
					// Collision - object physically deleted by another user.
					saveLogEntry.PostSaveObjectStatus = ObjectStatus.Deleted;
				else if (e.Collision.CollisionType == CollisionType.Update)
					// Collision - object updated by another user.
					saveLogEntry.PostSaveObjectStatus = ObjectStatus.Outdated;
				saveLog.Add(saveLogEntry);
				if (e.Collision.CollisionType == CollisionType.Delete)
				{
					saveLog.UpdateSaveLogForCascadeDelete((IEntityObject)attachment1);
				}
				// Rethrow the collision exception.
				throw;
			}
		}

		public override void DeleteAttachment1(Attachment1Identifier objectId, int updateId)
		{
			DeleteAttachment1Core(objectId, updateId, this.ignoreCollision);
		}

		public override void DeleteAttachment1(Attachment1Identifier objectId, int updateId, bool ignoreCollision)
		{
			DeleteAttachment1Core(objectId, updateId, ignoreCollision);
		}

		protected override void DeleteAttachment1Core(Attachment1Identifier objectId, int updateId, bool ignoreCollision)
		{
			try
			{
				if (this.attachment1DeleteCmd == null) CreateAttachment1DeleteCommand();
				SqlCommand cmd = this.attachment1DeleteCmd;

				// Set input parameters specific to the delete operation.

				cmd.Parameters["@p_attachment_1_id"].Value = objectId.Attachment1Id;
				if (ignoreCollision)
					cmd.Parameters["@p_ignore_collision_"].Value = 1;
				else
					cmd.Parameters["@p_ignore_collision_"].Value = 0;
				cmd.Parameters["@p_update_id_"].Value = updateId;

				// Call stored procedure.
				BeforeCommandExecute();
				cmd.ExecuteNonQuery();

				// Process results.

				switch ((int)cmd.Parameters["@p_rc_"].Value)
				{
					case 1: // Update successful.
						break;
					case 2: // Collision - object updated by another user.
						throw new SingleCollisionException(RepositoryExceptionMessage.UpdateCollisionDetected, EntityClass.Attachment1, objectId, CollisionType.Update, (string)cmd.Parameters["@p_user_"].Value, (DateTime)cmd.Parameters["@p_update_ts_"].Value);
					case 3: // Collision - object physically deleted by another user.
						throw new SingleCollisionException(RepositoryExceptionMessage.DeleteCollisionDetected, EntityClass.Attachment1, objectId, CollisionType.Delete, null, DateTime.MinValue);
				}
			}
			catch (SqlException e)
			{
				throw new DALException(RepositoryExceptionMessage.UnexpectedExceptionDetected, e);
			}
			finally
			{
				AfterCommandExecute();
			}
		}


		public override void SaveAttachment1(IAttachment1 attachment1)
		{
			SaveAttachment1Core(attachment1, this.ignoreCollision);
		}

		public override void SaveAttachment1(IAttachment1 attachment1, bool ignoreCollision)
		{
			SaveAttachment1Core(attachment1, ignoreCollision);
		}

		protected override void SaveAttachment1Core(IAttachment1 attachment1, bool ignoreCollision)
		{
			// When transaction support is added, ApplySaveLog must not be called if an exception is encountered.
			SaveLog saveLog = new SaveLog();
			try
			{
				SaveAttachment1Core(attachment1, ignoreCollision, saveLog);
				saveLog.ApplySaveLog();
			}
			catch (Exception)
			{
				// Still call ApplySaveLog because no support for transaction/rollback yet.
				saveLog.ApplySaveLog();
				// Reverse the commit state set by ApplySaveLog.
				attachment1.HasUncommittedChanges = true; // This line ensures that errors in saving dependent entities don't result in the parent being marked as uncommitted (because it isn't).
				throw;
			}
		}

		// The core function for saving a specific Attachment1 instance as well as related entity objects.
		// If an object is marked for deletion, this function calls DeleteAttachment1Core.
		// This function must NEVER update any properties of the entity object (attachment1).
		// Such updates must be cached in saveLog and applied by the caller depending upon whether or not an exception occurred and if the update is part of a transaction.
		protected override void SaveAttachment1Core(IAttachment1 attachment1, bool ignoreCollision, SaveLog saveLog)
		{
			if (attachment1.MarkedForDeletion)
			{
				// Database level cascade delete will take care of whatever dependent and relation entities are associated with Attachment1.
				DeleteAttachment1Core(attachment1, ignoreCollision, saveLog);
			}
			else
			{
				#region Entity Object

				bool insertOperation = SaveAttachment1EntityObjectCore(attachment1, ignoreCollision, saveLog);

				#endregion Entity Object

				#region Owned Child Entity Objects

				// This entity has no owned inbound relationships.

				#endregion Owned Child Entity Objects

			} // if (attachment1.MarkedForDeletion)
		}

		// The core function for saving a specific Attachment1 object.
		// It does not handle deletes (if the entity is marked for deletion) nor updating of related entity objects.
		// This function must NEVER update any properties of the entity object (attachment1).
		// Such updates must be cached in saveLog and applied by the caller depending upon whether or not an exception occurred and if the update is part of a transaction.
		protected override bool SaveAttachment1EntityObjectCore(IAttachment1 attachment1, bool ignoreCollision, SaveLog saveLog)
		{
			bool insertOperation;

			SaveLogEntry saveLogEntry = new SaveLogEntry();
			// These saveLogEntry assignments must occur here so that they are set if an exception occurs.
			saveLogEntry.EntityObject = attachment1;
			saveLogEntry.PreSaveObjectStatus = attachment1.ObjectStatus;

			try
			{
				insertOperation = !attachment1.ObjectId.HasValue;
				SqlCommand cmd;

				if (insertOperation)
				{
					// Have a new Attachment1 object to save.

					saveLogEntry.RepositoryUpdateOperation = RepositoryUpdateOperation.Insert;

					if (this.attachment1InsertCmd == null) CreateAttachment1InsertCommand();
					cmd = this.attachment1InsertCmd;
				}
				else
				{
					// Have a previously saved Attachment1 object to save.

					saveLogEntry.RepositoryUpdateOperation = RepositoryUpdateOperation.Update;

					if (this.attachment1UpdateCmd == null) CreateAttachment1UpdateCommand();
					cmd = this.attachment1UpdateCmd;

					// Set input parameters specific to the update operation.

					cmd.Parameters["@p_attachment_1_id"].Value = attachment1.Attachment1Id.Value;
					if (ignoreCollision)
						cmd.Parameters["@p_ignore_collision_"].Value = 1;
					else
						cmd.Parameters["@p_ignore_collision_"].Value = 0;
					cmd.Parameters["@p_update_id_"].Value = attachment1.UpdateId;
				}

				// Set input parameters common to both insert and update operations.

				// [dependent_entity_1_id]
				if (attachment1.DependentEntity1Id.HasValue)
					cmd.Parameters["@p_dependent_entity_1_id"].Value = attachment1.DependentEntity1Id.Value;
				else
					cmd.Parameters["@p_dependent_entity_1_id"].Value = DBNull.Value;
				// [attachment_notes]
				cmd.Parameters["@p_attachment_notes"].Value = attachment1.AttachmentNotes_DBObjectValue;
				// [attachment_type]
				cmd.Parameters["@p_attachment_type"].Value = attachment1.AttachmentType_DBObjectValue;
				// [attr_bool_1]
				cmd.Parameters["@p_attr_bool_1"].Value = attachment1.AttrBool1_DBObjectValue;
				// [attr_datetime_1]
				cmd.Parameters["@p_attr_datetime_1"].Value = attachment1.AttrDatetime1_DBObjectValue;
				// [attr_integer_1]
				cmd.Parameters["@p_attr_integer_1"].Value = attachment1.AttrInteger1_DBObjectValue;
				// [attr_string_1]
				cmd.Parameters["@p_attr_string_1"].Value = attachment1.AttrString1_DBObjectValue;
				// [attr_string_2]
				cmd.Parameters["@p_attr_string_2"].Value = attachment1.AttrString2_DBObjectValue;
				// FileAttachment = [file_attachment] + [file_name]
				if (attachment1.FileAttachment == null)
				{
					cmd.Parameters["@p_file_attachment"].Value = DBNull.Value;
					cmd.Parameters["@p_file_name"].Value = DBNull.Value;
					if (!insertOperation) cmd.Parameters["@p_file_attachment_no_update"].Value = false;
				}
				else
				{
					if (attachment1.FileAttachment.BlobAssigned)
					{
						cmd.Parameters["@p_file_attachment"].Value = attachment1.FileAttachment.Data;
						if (!insertOperation) cmd.Parameters["@p_file_attachment_no_update"].Value = false;
					}
					else
					{
						cmd.Parameters["@p_file_attachment"].Value = DBNull.Value;
						if (!insertOperation) cmd.Parameters["@p_file_attachment_no_update"].Value = true;
					}
					cmd.Parameters["@p_file_name"].Value = attachment1.FileAttachment.FileName;
				}
				// [name]
				cmd.Parameters["@p_name"].Value = attachment1.Name_DBObjectValue;
				// [status]
				cmd.Parameters["@p_status"].Value = attachment1.Status_DBObjectValue;
				cmd.Parameters["@p_user_"].Value = this.user;

				// Call stored procedure.
				BeforeCommandExecute();
				cmd.ExecuteNonQuery();

				// Process results.
				if (insertOperation)
				{
					saveLogEntry.PostSaveObjectStatus = ObjectStatus.Existing;
					((IEditableObject)attachment1).BeginEdit();
					Attachment1Identifier identifier = new Attachment1Identifier();
					identifier.Attachment1Id = (int)cmd.Parameters["@p_attachment_1_id"].Value;
					attachment1.ObjectId = identifier;
					attachment1.CreateTimestamp = (DateTime)cmd.Parameters["@p_update_ts_"].Value;
					attachment1.CreateUser = this.user;
				}
				else
				{
					int returnCode = (int)cmd.Parameters["@p_rc_"].Value;
					switch (returnCode)
					{
						case 1: // Update successful.
							saveLogEntry.PostSaveObjectStatus = ObjectStatus.Existing;
							((IEditableObject)attachment1).BeginEdit();
							attachment1.ObjectId = attachment1.ObjectId;
							attachment1.CreateTimestamp = attachment1.CreateTimestamp;
							attachment1.CreateUser = attachment1.CreateUser;
							break;
						case 2: // Collision - object updated by another user.
							throw new SingleCollisionException(RepositoryExceptionMessage.UpdateCollisionDetected, attachment1.EntityClass, attachment1.ObjectId, CollisionType.Update, (string)cmd.Parameters["@p_user_"].Value, (DateTime)cmd.Parameters["@p_update_ts_"].Value);
						case 3: // Collision - object physically deleted by another user.
							throw new SingleCollisionException(RepositoryExceptionMessage.DeleteCollisionDetected, attachment1.EntityClass, attachment1.ObjectId, CollisionType.Delete, null, DateTime.MinValue);
					}
				}
				attachment1.LastUpdateTimestamp = (DateTime)cmd.Parameters["@p_update_ts_"].Value;
				attachment1.LastUpdateUser = this.user;
				if (cmd.Parameters["@p_update_id_"].Value == DBNull.Value)
					attachment1.UpdateId = 0;
				else
					attachment1.UpdateId = (int)cmd.Parameters["@p_update_id_"].Value;
				saveLog.Add(saveLogEntry); // SaveLog takes care of calling EndEdit.
			}
			catch (SingleCollisionException e)
			{
				if (e.Collision.CollisionType == CollisionType.Delete)
					saveLogEntry.PostSaveObjectStatus = ObjectStatus.Deleted;
				else if (e.Collision.CollisionType == CollisionType.Update)
					saveLogEntry.PostSaveObjectStatus = ObjectStatus.Outdated;
				saveLog.Add(saveLogEntry);
				if (e.Collision.CollisionType == CollisionType.Delete)
					saveLog.UpdateSaveLogForCascadeDelete((IEntityObject)attachment1);
				throw;
			}
			catch (SqlException e)
			{
				throw new DALException(RepositoryExceptionMessage.UnexpectedExceptionDetected, e);
			}
			finally
			{
				AfterCommandExecute();
			}

			return insertOperation;
		}

		protected virtual IAttachment1 OnAttachment1Load(IAttachment1 attachment1)
		{
			return attachment1;
		}

		#endregion Attachment1 related members.

		#region DependentEntity1 related members.

		public override IDependentEntity1List FindDependentEntity1(int maxCount, SearchCondition searchCondition)
		{
			return this.FindDependentEntity1(maxCount, searchCondition, null, null);
		}

		public override IDependentEntity1List FindDependentEntity1(int maxCount, SearchCondition searchCondition, SortSpecification sortSpecification)
		{
			return this.FindDependentEntity1(maxCount, searchCondition, sortSpecification, null);
		}

		public override IDependentEntity1List FindDependentEntity1(int maxCount, SearchCondition searchCondition, IEntityObjectContext context)
		{
			return this.FindDependentEntity1(maxCount, searchCondition, null, context);
		}

		public override IDependentEntity1List FindDependentEntity1(int maxCount, SearchCondition searchCondition, SortSpecification sortSpecification, IEntityObjectContext context)
		{
			try
			{
				string sql = "SELECT ";
				if (maxCount > -1) sql += "TOP " + maxCount.ToString("d") + " ";
				sql +=
				"[dependent_entity_1_id]," +
				"[independent_entity_1_id]," +
				"[attr_bool_1]," +
				"[attr_datetime_1]," +
				"[attr_integer_1]," +
				"[attr_string_1]," +
				"[attr_string_2]," +
				"[name]," +
				"[status]," +
				"[create_datetime]," +
				"[create_user]," +
				"[update_datetime]," +
				"[update_id]," +
				"[update_user]" +
				" FROM [dependent_entity_1]";
				SqlCommand cmd = new SqlCommand();
				cmd.CommandTimeout = this.commandTimeout;
				cmd.Connection = this.connection;
				//
				// Add SQL Where criteria if required.
				//
				string whereClause;
				ArrayList whereClauseParameters;
				BuildWhereClause(searchCondition, out whereClause, out whereClauseParameters);
				if (whereClause != null && whereClause != "")
				{
					sql = sql + " WHERE " + whereClause;
					foreach (SqlParameter param in whereClauseParameters)
					{
						cmd.Parameters.Add(param);
					}
				}
				//
				// Add SQL ORDER BY clause if required.
				//
				string orderByClause;
				if (sortSpecification == null)
					orderByClause = BuildOrderByClause(this.dependentEntity1SortSpecification);
				else
					orderByClause = BuildOrderByClause(sortSpecification);
				if (orderByClause != null && orderByClause != "")
					sql += " ORDER BY " + orderByClause;
				//
				// Execute SQL Select command and convert results into a list of DependentEntity1 objects.
				//
				cmd.CommandText = sql;
				cmd.CommandType = CommandType.Text;
				BeforeCommandExecute();
				SqlDataReader sdr = cmd.ExecuteReader();
				IDependentEntity1List dependentEntity1List = (IDependentEntity1List)this.classFactory.GetEntityListObject(EntityClass.DependentEntity1);
				if (sdr.HasRows)
				{
					if (context == null)
					{
						while (sdr.Read())
						{
							dependentEntity1List.Add(CreateDependentEntity1FromSqlDataReader(sdr));
						}
					}
					else
					{
						DependentEntity1Identifier? identifier;
						IEntityObjectContextItem obj;
						while (sdr.Read())
						{
							// Get the primary object id.
							identifier = CreateDependentEntity1IdentifierFromSqlDataReader(sdr, 0);
							if (identifier == null)
							{
								dependentEntity1List.Add(CreateDependentEntity1FromSqlDataReader(sdr));
							}
							else
							{
								if ((obj = context.Get((IIdentifier)identifier.Value)) == null)
									dependentEntity1List.Add(CreateDependentEntity1FromSqlDataReader(sdr));
								else
									dependentEntity1List.Add(obj);
							}
						}
					}
				}
				sdr.Close();

				return dependentEntity1List;
			}
			catch (SqlException e)
			{
				throw new DALException(RepositoryExceptionMessage.UnexpectedExceptionDetected, e);
			}
			finally
			{
				AfterCommandExecute();
			}
		}

		// Parameter propertyName must be a DependentEntity1PropertyName class constant (DependentEntity1BasePropertyName is a subset of DependentEntity1PropertyName).
		public override ArrayList GetAssociatedDependentEntity1Ids(int maxCount, DependentEntity1PropertyName propertyName, object value)
		{
			try
			{
				// Create SQL command.

				string sql = "SELECT ";
				if (maxCount > -1) sql += "TOP " + maxCount.ToString("d") + " ";
				sql +=
				"[dependent_entity_1_id] " +
				"FROM [dependent_entity_1]";

				// Add Where condition.

				SearchCondition searchCondition = new SearchCondition().AppendSearchCondition(propertyName, SearchConditionExpressionOperator.Equal, value);
				string whereClause;
				ArrayList whereClauseParameters;
				BuildWhereClause(searchCondition, out whereClause, out whereClauseParameters);
				sql = sql + " WHERE " + whereClause;
				SqlCommand cmd = new SqlCommand(sql, this.connection);
				cmd.CommandTimeout = this.commandTimeout;
				cmd.CommandType = CommandType.Text;
				foreach (SqlParameter param in whereClauseParameters)
					cmd.Parameters.Add(param);

				// Execute query.

				BeforeCommandExecute();
				SqlDataReader sdr = cmd.ExecuteReader();
				ArrayList dependentEntity1IdentifierList = new ArrayList();
				if (sdr.HasRows)
				{
					while (sdr.Read())
						dependentEntity1IdentifierList.Add(CreateDependentEntity1IdentifierFromSqlDataReader(sdr, 0));
				}
				sdr.Close();

				return dependentEntity1IdentifierList;
			}
			catch (SqlException e)
			{
				throw new DALException(RepositoryExceptionMessage.UnexpectedExceptionDetected, e);
			}
			finally
			{
				AfterCommandExecute();
			}
		}

		public SortSpecification DependentEntity1SortSpecification
		{
			get
			{
				return this.dependentEntity1SortSpecification;
			}
			set
			{
				this.dependentEntity1SortSpecification = value;
			}
		}

		public virtual SortSpecification DependentEntity1DefaultSortSpecification
		{
			get
			{
				return null;
			}
		}

		public override SortSpecification DependentEntity1_ChildOwnedAttachment1SortSpecification
		{
			get
			{
				return this.dependentEntity1_ChildOwnedAttachment1SortSpecification;
			}
			set
			{
				this.dependentEntity1_ChildOwnedAttachment1SortSpecification = value;
			}
		}

		public virtual SortSpecification DependentEntity1_ChildOwnedAttachment1DefaultSortSpecification
		{
			get
			{
				return null;
			}
		}

		public override SortSpecification DependentEntity1_ChildOwnedDependentEntity2SortSpecification
		{
			get
			{
				return this.dependentEntity1_ChildOwnedDependentEntity2SortSpecification;
			}
			set
			{
				this.dependentEntity1_ChildOwnedDependentEntity2SortSpecification = value;
			}
		}

		public virtual SortSpecification DependentEntity1_ChildOwnedDependentEntity2DefaultSortSpecification
		{
			get
			{
				return null;
			}
		}

		protected override void DeleteDependentEntity1(SearchCondition searchCondition)
		{
			// To avoid accidental deletion of all DependentEntity1 objects, insist on a search condition.
			bool haveSearchCondition;
			if (searchCondition == null)
				haveSearchCondition = false;
			else
				haveSearchCondition = (!searchCondition.IsNullCondition());
			if (!haveSearchCondition) throw new DALException(RepositoryExceptionMessage.NonEmptySearchConditionRequired);

			try
			{
				SqlCommand cmd = new SqlCommand();
				cmd.CommandTimeout = this.commandTimeout;
				cmd.Connection = this.connection;
				string sql = "DELETE FROM [dependent_entity_1]";
				//
				// Add SQL Where criteria if required.
				//
				string sqlWhereConditionText;
				ArrayList sqlWhereConditionParameters;
				BuildWhereClause(searchCondition, out sqlWhereConditionText, out sqlWhereConditionParameters);
				if (sqlWhereConditionText != null && sqlWhereConditionText != "")
				{
					sql = sql + " WHERE " + sqlWhereConditionText;
					foreach (SqlParameter param in sqlWhereConditionParameters)
					{
						cmd.Parameters.Add(param);
					}
				}
				cmd.CommandText = sql;
				cmd.CommandType = CommandType.Text;
				//
				// Execute SQL Delete command.
				//
				BeforeCommandExecute();
				cmd.ExecuteNonQuery();
			}
			catch (SqlException e)
			{
				throw new DALException(RepositoryExceptionMessage.UnexpectedExceptionDetected, e);
			}
			finally
			{
				AfterCommandExecute();
			}
		}


		public override IDependentEntity1 GetDependentEntity1(DependentEntity1Identifier objectId)
		{
			return this.GetDependentEntity1(objectId, null);
		}

		public override IDependentEntity1 GetDependentEntity1(DependentEntity1Identifier objectId, IEntityObjectContext context)
		{
			try
			{
				IDependentEntity1 dependentEntity1 = null;

				if (context == null || (context != null && (dependentEntity1 = (IDependentEntity1)context.Get((IIdentifier)objectId)) == null))
				{
					if (this.dependentEntity1GetCmd == null) CreateDependentEntity1GetCommand();
					SqlCommand cmd = this.dependentEntity1GetCmd;

					// Set input parameters.
					cmd.Parameters["@p_dependent_entity_1_id"].Value = objectId.DependentEntity1Id;

					// Call stored procedure.
					BeforeCommandExecute();
					cmd.ExecuteNonQuery();

					// Process results.

					if ((int)cmd.Parameters["@p_rc_"].Value == 1)
					{
						// Object retrieved successfully.

						dependentEntity1 = (IDependentEntity1)this.classFactory.GetEntityObject(EntityClass.DependentEntity1);
						dependentEntity1.ObjectId = objectId;
						bool foundNullValue;
						// Process foreign key fields associated with the IndependentEntity1 owner relationship.
						foundNullValue = (cmd.Parameters["@p_independent_entity_1_id"].Value == DBNull.Value);
						if (foundNullValue)
						{
							dependentEntity1.ParentOwnerIndependentEntity1EntityObjectId = null;
						}
						else
						{
							IndependentEntity1Identifier identifier0 = new IndependentEntity1Identifier();
							identifier0.IndependentEntity1Id = (int)cmd.Parameters["@p_independent_entity_1_id"].Value;
							dependentEntity1.ParentOwnerIndependentEntity1EntityObjectId = identifier0;
						}
						// [attr_bool_1]
						if (cmd.Parameters["@p_attr_bool_1"].Value == DBNull.Value)
						{
							dependentEntity1.AttrBool1 = null;
						}
						else
						{
							dependentEntity1.AttrBool1 = (bool)cmd.Parameters["@p_attr_bool_1"].Value;
						}
						// [attr_datetime_1]
						if (cmd.Parameters["@p_attr_datetime_1"].Value == DBNull.Value)
						{
							dependentEntity1.AttrDatetime1 = null;
						}
						else
						{
							dependentEntity1.AttrDatetime1 = (DateTime)cmd.Parameters["@p_attr_datetime_1"].Value;
						}
						// [attr_integer_1]
						if (cmd.Parameters["@p_attr_integer_1"].Value == DBNull.Value)
						{
							dependentEntity1.AttrInteger1 = null;
						}
						else
						{
							dependentEntity1.AttrInteger1 = (int)cmd.Parameters["@p_attr_integer_1"].Value;
						}
						// [attr_string_1]
						if (cmd.Parameters["@p_attr_string_1"].Value == DBNull.Value)
						{
							dependentEntity1.AttrString1 = null;
						}
						else
						{
							dependentEntity1.AttrString1 = (string)cmd.Parameters["@p_attr_string_1"].Value;
						}
						// [attr_string_2]
						if (cmd.Parameters["@p_attr_string_2"].Value == DBNull.Value)
						{
							dependentEntity1.AttrString2 = null;
						}
						else
						{
							dependentEntity1.AttrString2 = (string)cmd.Parameters["@p_attr_string_2"].Value;
						}
						// [name]
						if (cmd.Parameters["@p_name"].Value == DBNull.Value)
						{
							dependentEntity1.Name = null;
						}
						else
						{
							dependentEntity1.Name = (string)cmd.Parameters["@p_name"].Value;
						}
						// [status]
						if (cmd.Parameters["@p_status"].Value == DBNull.Value)
						{
							dependentEntity1.Status = null;
						}
						else
						{
							dependentEntity1.Status = (string)cmd.Parameters["@p_status"].Value;
						}
						// [create_datetime]
						if (cmd.Parameters["@p_create_datetime"].Value == DBNull.Value)
							dependentEntity1.CreateTimestamp = null;
						else
							dependentEntity1.CreateTimestamp = (DateTime)cmd.Parameters["@p_create_datetime"].Value;
						// [create_user]
						if (cmd.Parameters["@p_create_user"].Value == DBNull.Value)
							dependentEntity1.CreateUser = null;
						else
							dependentEntity1.CreateUser = (string)cmd.Parameters["@p_create_user"].Value;
						// [update_datetime]
						if (cmd.Parameters["@p_update_datetime"].Value == DBNull.Value)
							dependentEntity1.LastUpdateTimestamp = null;
						else
							dependentEntity1.LastUpdateTimestamp = (DateTime)cmd.Parameters["@p_update_datetime"].Value;
						// [update_id]
						if (cmd.Parameters["@p_update_id"].Value == DBNull.Value)
							dependentEntity1.UpdateId = 0;
						else
							dependentEntity1.UpdateId = (int)cmd.Parameters["@p_update_id"].Value;
						// [update_user]
						if (cmd.Parameters["@p_update_user"].Value == DBNull.Value)
							dependentEntity1.LastUpdateUser = null;
						else
							dependentEntity1.LastUpdateUser = (string)cmd.Parameters["@p_update_user"].Value;
						dependentEntity1.ObjectStatus = ObjectStatus.Existing;
						dependentEntity1.HasUncommittedChanges = false;
					}

					// Add newly loaded object to context.
					if (context != null)
						context.Add((IEntityObjectContextItem)dependentEntity1);
				}

				return this.OnDependentEntity1Load(dependentEntity1);
			}
			catch (SqlException e)
			{
				throw new DALException(RepositoryExceptionMessage.UnexpectedExceptionDetected, e);
			}
			finally
			{
				AfterCommandExecute();
			}
		}

		public override byte[] GetDependentEntity1BLOB(DependentEntity1Identifier objectId, int updateId, string columnName)
		{
			return GetDependentEntity1BLOBCore(objectId, updateId, columnName, this.ignoreCollision);
		}

		public override byte[] GetDependentEntity1BLOB(DependentEntity1Identifier objectId, int updateId, string columnName, bool ignoreCollision)
		{
			return GetDependentEntity1BLOBCore(objectId, updateId, columnName, ignoreCollision);
		}

		protected override byte[] GetDependentEntity1BLOBCore(DependentEntity1Identifier objectId, int updateId, string columnName, bool ignoreCollision)
		{
			try
			{
				if (this.dependentEntity1GetBLOBCmd == null)
					CreateDependentEntity1GetBLOBCommand();
				SqlCommand cmd = this.dependentEntity1GetBLOBCmd;

				// Set input parameters.

				cmd.Parameters["@p_dependent_entity_1_id"].Value = objectId.DependentEntity1Id;
				if (ignoreCollision)
					cmd.Parameters["@p_ignore_collision_"].Value = 1;
				else
					cmd.Parameters["@p_ignore_collision_"].Value = 0;
				cmd.Parameters["@p_update_id_"].Value = updateId;
				cmd.Parameters["@p_column_name_"].Value = columnName;

				// Call stored procedure.
				BeforeCommandExecute();
				cmd.ExecuteNonQuery();

				// Process results.

				switch ((int)cmd.Parameters["@p_rc_"].Value)
				{
					case 1: // Fetch successful.
						if (cmd.Parameters["@p_blob_"].Value == DBNull.Value)
							return null;
						else
							return (byte[])cmd.Parameters["@p_blob_"].Value;
					case 2: // Collision - object updated by another user.
						throw new SingleCollisionException(RepositoryExceptionMessage.UpdateCollisionDetected, EntityClass.DependentEntity1, objectId, CollisionType.Update, (string)cmd.Parameters["@p_user_"].Value, (DateTime)cmd.Parameters["@p_update_ts_"].Value);
					case 3: // Collision - object physically deleted by another user.
						throw new SingleCollisionException(RepositoryExceptionMessage.DeleteCollisionDetected, EntityClass.DependentEntity1, objectId, CollisionType.Delete, null, DateTime.MinValue);
					default:
						return null;
				}
			}
			catch (SqlException e)
			{
				throw new DALException(RepositoryExceptionMessage.UnexpectedExceptionDetected, e);
			}
			finally
			{
				AfterCommandExecute();
			}
		}


		public override void DeleteDependentEntity1(IDependentEntity1 dependentEntity1)
		{
			DeleteDependentEntity1Core(dependentEntity1, this.ignoreCollision);
		}

		public override void DeleteDependentEntity1(IDependentEntity1 dependentEntity1, bool ignoreCollision)
		{
			DeleteDependentEntity1Core(dependentEntity1, ignoreCollision);
		}

		protected override void DeleteDependentEntity1Core(IDependentEntity1 dependentEntity1, bool ignoreCollision)
		{
			// When transaction support is added, ApplySaveLog must not be called if an exception is encountered.
			SaveLog saveLog = new SaveLog();
			try
			{
				DeleteDependentEntity1Core(dependentEntity1, ignoreCollision, saveLog);
				saveLog.ApplySaveLog();
			}
			catch (Exception)
			{
				// Still call ApplySaveLog because no support for transaction/rollback yet.
				saveLog.ApplySaveLog();
				throw;
			}
		}

		// Because cascade delete operations are handled at the DB level, this implementation of this function is trivial.
		protected override void DeleteDependentEntity1Core(IDependentEntity1 dependentEntity1, bool ignoreCollision, SaveLog saveLog)
		{
			DeleteDependentEntity1EntityObjectCore(dependentEntity1, ignoreCollision, saveLog);
		}

		protected override void DeleteDependentEntity1EntityObjectCore(IDependentEntity1 dependentEntity1, bool ignoreCollision, SaveLog saveLog)
		{
			SaveLogEntry saveLogEntry = new SaveLogEntry();
			// These saveLogEntry assignments must occur here so that they are set if an exception occurs.
			saveLogEntry.EntityObject = dependentEntity1;
			saveLogEntry.PreSaveObjectStatus = dependentEntity1.ObjectStatus;
			try
			{
				saveLogEntry.RepositoryUpdateOperation = RepositoryUpdateOperation.Delete;

				DeleteDependentEntity1((DependentEntity1Identifier)dependentEntity1.ObjectId, dependentEntity1.UpdateId, ignoreCollision);

				saveLogEntry.PostSaveObjectStatus = ObjectStatus.Deleted;
				saveLog.Add(saveLogEntry);
				// Add SaveLog entries for in-memory objects owned by dependentEntity1 that must have been cascade deleted by the repository.
				saveLog.UpdateSaveLogForCascadeDelete((IEntityObject)dependentEntity1);
			}
			catch (SingleCollisionException e)
			{
				// Update the object's status to reflect the collision.
				if (e.Collision.CollisionType == CollisionType.Delete)
					// Collision - object physically deleted by another user.
					saveLogEntry.PostSaveObjectStatus = ObjectStatus.Deleted;
				else if (e.Collision.CollisionType == CollisionType.Update)
					// Collision - object updated by another user.
					saveLogEntry.PostSaveObjectStatus = ObjectStatus.Outdated;
				saveLog.Add(saveLogEntry);
				if (e.Collision.CollisionType == CollisionType.Delete)
				{
					saveLog.UpdateSaveLogForCascadeDelete((IEntityObject)dependentEntity1);
				}
				// Rethrow the collision exception.
				throw;
			}
		}

		public override void DeleteDependentEntity1(DependentEntity1Identifier objectId, int updateId)
		{
			DeleteDependentEntity1Core(objectId, updateId, this.ignoreCollision);
		}

		public override void DeleteDependentEntity1(DependentEntity1Identifier objectId, int updateId, bool ignoreCollision)
		{
			DeleteDependentEntity1Core(objectId, updateId, ignoreCollision);
		}

		protected override void DeleteDependentEntity1Core(DependentEntity1Identifier objectId, int updateId, bool ignoreCollision)
		{
			try
			{
				if (this.dependentEntity1DeleteCmd == null) CreateDependentEntity1DeleteCommand();
				SqlCommand cmd = this.dependentEntity1DeleteCmd;

				// Set input parameters specific to the delete operation.

				cmd.Parameters["@p_dependent_entity_1_id"].Value = objectId.DependentEntity1Id;
				if (ignoreCollision)
					cmd.Parameters["@p_ignore_collision_"].Value = 1;
				else
					cmd.Parameters["@p_ignore_collision_"].Value = 0;
				cmd.Parameters["@p_update_id_"].Value = updateId;

				// Call stored procedure.
				BeforeCommandExecute();
				cmd.ExecuteNonQuery();

				// Process results.

				switch ((int)cmd.Parameters["@p_rc_"].Value)
				{
					case 1: // Update successful.
						break;
					case 2: // Collision - object updated by another user.
						throw new SingleCollisionException(RepositoryExceptionMessage.UpdateCollisionDetected, EntityClass.DependentEntity1, objectId, CollisionType.Update, (string)cmd.Parameters["@p_user_"].Value, (DateTime)cmd.Parameters["@p_update_ts_"].Value);
					case 3: // Collision - object physically deleted by another user.
						throw new SingleCollisionException(RepositoryExceptionMessage.DeleteCollisionDetected, EntityClass.DependentEntity1, objectId, CollisionType.Delete, null, DateTime.MinValue);
				}
			}
			catch (SqlException e)
			{
				throw new DALException(RepositoryExceptionMessage.UnexpectedExceptionDetected, e);
			}
			finally
			{
				AfterCommandExecute();
			}
		}


		public override void SaveDependentEntity1(IDependentEntity1 dependentEntity1)
		{
			SaveDependentEntity1Core(dependentEntity1, this.ignoreCollision);
		}

		public override void SaveDependentEntity1(IDependentEntity1 dependentEntity1, bool ignoreCollision)
		{
			SaveDependentEntity1Core(dependentEntity1, ignoreCollision);
		}

		protected override void SaveDependentEntity1Core(IDependentEntity1 dependentEntity1, bool ignoreCollision)
		{
			// When transaction support is added, ApplySaveLog must not be called if an exception is encountered.
			SaveLog saveLog = new SaveLog();
			try
			{
				SaveDependentEntity1Core(dependentEntity1, ignoreCollision, saveLog);
				saveLog.ApplySaveLog();
			}
			catch (Exception)
			{
				// Still call ApplySaveLog because no support for transaction/rollback yet.
				saveLog.ApplySaveLog();
				// Reverse the commit state set by ApplySaveLog.
				dependentEntity1.HasUncommittedChanges = true; // This line ensures that errors in saving dependent entities don't result in the parent being marked as uncommitted (because it isn't).
				throw;
			}
		}

		// The core function for saving a specific DependentEntity1 instance as well as related entity objects.
		// If an object is marked for deletion, this function calls DeleteDependentEntity1Core.
		// This function must NEVER update any properties of the entity object (dependentEntity1).
		// Such updates must be cached in saveLog and applied by the caller depending upon whether or not an exception occurred and if the update is part of a transaction.
		protected override void SaveDependentEntity1Core(IDependentEntity1 dependentEntity1, bool ignoreCollision, SaveLog saveLog)
		{
			if (dependentEntity1.MarkedForDeletion)
			{
				// Database level cascade delete will take care of whatever dependent and relation entities are associated with DependentEntity1.
				DeleteDependentEntity1Core(dependentEntity1, ignoreCollision, saveLog);
			}
			else
			{
				#region Entity Object

				bool insertOperation = SaveDependentEntity1EntityObjectCore(dependentEntity1, ignoreCollision, saveLog);

				#endregion Entity Object

				#region Owned Child Entity Objects

				// Save child Attachment1 objects.
				// Relationship has a cardinality of many.
				switch (dependentEntity1.ChildOwnedAttachment1ListLoadStatus)
				{
					case LoadStatus.Full:
						// The content of the child collection is what the repository should be synchronized with.
						if (dependentEntity1.HasChildOwnedAttachment1Objects(false))
						{
							if (insertOperation)
							{
								// This is the first time the parent DependentEntity1 object has been saved.
								// Therefore, it cannot have any child Attachment1 objects in the repository.
								// Therefore, it is not necessary to check the repository to determine if existing child objects need to be removed because they are not associated with the in-memory copy of the parent object.
								this.Save((IList)dependentEntity1.ChildOwnedAttachment1List, false);
							}
							else
							{
								// Since the parent DependentEntity1 object existed in the repository prior to this call to save, it is possible that there already exist child Attachment1 objects in the repository.
								// The repository set of child Attachment1 objects has to be synchronized with the in-memory set.

								// Get a list of object ids of Attachment1 objects associated with the database copy of DependentEntity1.
								ArrayList attachment1Ids = GetAssociatedAttachment1Ids(-1, Attachment1PropertyName.ParentOwnerDependentEntity1EntityObjectId, dependentEntity1.ObjectId);

								// Remove from the list ids of Attachment1 objects that are related to the in-memory copy of DependentEntity1.
								// After this is done, the list will contain ids of those Attachment1 objects that must be deleted from the repository since they are no longer related to the in-memory copy of DependentEntity1.
								attachment1Ids.Sort();
								int index;
								foreach (IAttachment1 childAttachment1 in dependentEntity1.ChildOwnedAttachment1List)
								{
									index = attachment1Ids.BinarySearch(childAttachment1.ObjectId);
									if (index >= 0) attachment1Ids.RemoveAt(index);
								}

								// The remaining ids in attachment1Ids collection identify the Attachment1 objects to be deleted from the database, since they are no longer related to the in-memory copy of DependentEntity1.
								for (index = 0; index < attachment1Ids.Count; ++index)
									// The following delete call sets ignoreCollision = true.
									// This is because update ids were not loaded along with the object ids.
									// Without update ids, collision detection isn't possible.
									// There is no need for collision detection at this point anyway, because the parent DependentEntity1 object
									// has passed its collision test.
									DeleteAttachment1Core((Attachment1Identifier)attachment1Ids[index], 0, true); // If ignoreCollision = true, updateId is ignored.

								// Save the child entity objects.
								this.Save((IList)dependentEntity1.ChildOwnedAttachment1List, true);
							} // if (insertOperation)
						}
						else
						{
							// The LoadStatus is Full and the child collecton is empty.
							// If the parent DependentEntity1 object existed in the repository prior to this save, there is a chance the repository copy has child Attachment1 objects that must be deleted.
							if (!insertOperation)
							{
								// Delete any child Attachment1 object that may exist in the repository.
								// The most efficient way to synchronize the database is to simply issue a bulk erase call to remove all associated Attachment1 objects from the database.
								this.DeleteAttachment1(new SearchCondition().AppendSearchCondition(Attachment1PropertyName.ParentOwnerDependentEntity1EntityObjectId, SearchConditionExpressionOperator.Equal, dependentEntity1.ObjectId));
							}
						} // if (dependentEntity1.HasChildOwnedAttachment1Objects(false))
						break;
					case LoadStatus.Partial:
						// Update the set of child Attachment1 objects in the repository to be the union of the existing child objects in the repository and the in-memory child objects.
						if (dependentEntity1.HasChildOwnedAttachment1Objects(false))
							this.Save((IList)dependentEntity1.ChildOwnedAttachment1List, true);
						break;
					case LoadStatus.NotLoaded:
						// In-memory copy of DependentEntity1 has the same child Attachment1 objects as the respository counterpart does.
						// Therefore, no repository update is required.
						break;
				}

				// Save child DependentEntity2 objects.
				// Relationship has a cardinality of many.
				switch (dependentEntity1.ChildOwnedDependentEntity2ListLoadStatus)
				{
					case LoadStatus.Full:
						// The content of the child collection is what the repository should be synchronized with.
						if (dependentEntity1.HasChildOwnedDependentEntity2Objects(false))
						{
							if (insertOperation)
							{
								// This is the first time the parent DependentEntity1 object has been saved.
								// Therefore, it cannot have any child DependentEntity2 objects in the repository.
								// Therefore, it is not necessary to check the repository to determine if existing child objects need to be removed because they are not associated with the in-memory copy of the parent object.
								this.Save((IList)dependentEntity1.ChildOwnedDependentEntity2List, false);
							}
							else
							{
								// Since the parent DependentEntity1 object existed in the repository prior to this call to save, it is possible that there already exist child DependentEntity2 objects in the repository.
								// The repository set of child DependentEntity2 objects has to be synchronized with the in-memory set.

								// Get a list of object ids of DependentEntity2 objects associated with the database copy of DependentEntity1.
								ArrayList dependentEntity2Ids = GetAssociatedDependentEntity2Ids(-1, DependentEntity2PropertyName.ParentOwnerDependentEntity1EntityObjectId, dependentEntity1.ObjectId);

								// Remove from the list ids of DependentEntity2 objects that are related to the in-memory copy of DependentEntity1.
								// After this is done, the list will contain ids of those DependentEntity2 objects that must be deleted from the repository since they are no longer related to the in-memory copy of DependentEntity1.
								dependentEntity2Ids.Sort();
								int index;
								foreach (IDependentEntity2 childDependentEntity2 in dependentEntity1.ChildOwnedDependentEntity2List)
								{
									index = dependentEntity2Ids.BinarySearch(childDependentEntity2.ObjectId);
									if (index >= 0) dependentEntity2Ids.RemoveAt(index);
								}

								// The remaining ids in dependentEntity2Ids collection identify the DependentEntity2 objects to be deleted from the database, since they are no longer related to the in-memory copy of DependentEntity1.
								for (index = 0; index < dependentEntity2Ids.Count; ++index)
									// The following delete call sets ignoreCollision = true.
									// This is because update ids were not loaded along with the object ids.
									// Without update ids, collision detection isn't possible.
									// There is no need for collision detection at this point anyway, because the parent DependentEntity1 object
									// has passed its collision test.
									DeleteDependentEntity2Core((DependentEntity2Identifier)dependentEntity2Ids[index], 0, true); // If ignoreCollision = true, updateId is ignored.

								// Save the child entity objects.
								this.Save((IList)dependentEntity1.ChildOwnedDependentEntity2List, true);
							} // if (insertOperation)
						}
						else
						{
							// The LoadStatus is Full and the child collecton is empty.
							// If the parent DependentEntity1 object existed in the repository prior to this save, there is a chance the repository copy has child DependentEntity2 objects that must be deleted.
							if (!insertOperation)
							{
								// Delete any child DependentEntity2 object that may exist in the repository.
								// The most efficient way to synchronize the database is to simply issue a bulk erase call to remove all associated DependentEntity2 objects from the database.
								this.DeleteDependentEntity2(new SearchCondition().AppendSearchCondition(DependentEntity2PropertyName.ParentOwnerDependentEntity1EntityObjectId, SearchConditionExpressionOperator.Equal, dependentEntity1.ObjectId));
							}
						} // if (dependentEntity1.HasChildOwnedDependentEntity2Objects(false))
						break;
					case LoadStatus.Partial:
						// Update the set of child DependentEntity2 objects in the repository to be the union of the existing child objects in the repository and the in-memory child objects.
						if (dependentEntity1.HasChildOwnedDependentEntity2Objects(false))
							this.Save((IList)dependentEntity1.ChildOwnedDependentEntity2List, true);
						break;
					case LoadStatus.NotLoaded:
						// In-memory copy of DependentEntity1 has the same child DependentEntity2 objects as the respository counterpart does.
						// Therefore, no repository update is required.
						break;
				}


				#endregion Owned Child Entity Objects

			} // if (dependentEntity1.MarkedForDeletion)
		}

		// The core function for saving a specific DependentEntity1 object.
		// It does not handle deletes (if the entity is marked for deletion) nor updating of related entity objects.
		// This function must NEVER update any properties of the entity object (dependentEntity1).
		// Such updates must be cached in saveLog and applied by the caller depending upon whether or not an exception occurred and if the update is part of a transaction.
		protected override bool SaveDependentEntity1EntityObjectCore(IDependentEntity1 dependentEntity1, bool ignoreCollision, SaveLog saveLog)
		{
			bool insertOperation;

			SaveLogEntry saveLogEntry = new SaveLogEntry();
			// These saveLogEntry assignments must occur here so that they are set if an exception occurs.
			saveLogEntry.EntityObject = dependentEntity1;
			saveLogEntry.PreSaveObjectStatus = dependentEntity1.ObjectStatus;

			try
			{
				insertOperation = !dependentEntity1.ObjectId.HasValue;
				SqlCommand cmd;

				if (insertOperation)
				{
					// Have a new DependentEntity1 object to save.

					saveLogEntry.RepositoryUpdateOperation = RepositoryUpdateOperation.Insert;

					if (this.dependentEntity1InsertCmd == null) CreateDependentEntity1InsertCommand();
					cmd = this.dependentEntity1InsertCmd;
				}
				else
				{
					// Have a previously saved DependentEntity1 object to save.

					saveLogEntry.RepositoryUpdateOperation = RepositoryUpdateOperation.Update;

					if (this.dependentEntity1UpdateCmd == null) CreateDependentEntity1UpdateCommand();
					cmd = this.dependentEntity1UpdateCmd;

					// Set input parameters specific to the update operation.

					cmd.Parameters["@p_dependent_entity_1_id"].Value = dependentEntity1.DependentEntity1Id.Value;
					if (ignoreCollision)
						cmd.Parameters["@p_ignore_collision_"].Value = 1;
					else
						cmd.Parameters["@p_ignore_collision_"].Value = 0;
					cmd.Parameters["@p_update_id_"].Value = dependentEntity1.UpdateId;
				}

				// Set input parameters common to both insert and update operations.

				// [independent_entity_1_id]
				if (dependentEntity1.IndependentEntity1Id.HasValue)
					cmd.Parameters["@p_independent_entity_1_id"].Value = dependentEntity1.IndependentEntity1Id.Value;
				else
					cmd.Parameters["@p_independent_entity_1_id"].Value = DBNull.Value;
				// [attr_bool_1]
				cmd.Parameters["@p_attr_bool_1"].Value = dependentEntity1.AttrBool1_DBObjectValue;
				// [attr_datetime_1]
				cmd.Parameters["@p_attr_datetime_1"].Value = dependentEntity1.AttrDatetime1_DBObjectValue;
				// [attr_integer_1]
				cmd.Parameters["@p_attr_integer_1"].Value = dependentEntity1.AttrInteger1_DBObjectValue;
				// [attr_string_1]
				cmd.Parameters["@p_attr_string_1"].Value = dependentEntity1.AttrString1_DBObjectValue;
				// [attr_string_2]
				cmd.Parameters["@p_attr_string_2"].Value = dependentEntity1.AttrString2_DBObjectValue;
				// [name]
				cmd.Parameters["@p_name"].Value = dependentEntity1.Name_DBObjectValue;
				// [status]
				cmd.Parameters["@p_status"].Value = dependentEntity1.Status_DBObjectValue;
				cmd.Parameters["@p_user_"].Value = this.user;

				// Call stored procedure.
				BeforeCommandExecute();
				cmd.ExecuteNonQuery();

				// Process results.
				if (insertOperation)
				{
					saveLogEntry.PostSaveObjectStatus = ObjectStatus.Existing;
					((IEditableObject)dependentEntity1).BeginEdit();
					DependentEntity1Identifier identifier = new DependentEntity1Identifier();
					identifier.DependentEntity1Id = (int)cmd.Parameters["@p_dependent_entity_1_id"].Value;
					dependentEntity1.ObjectId = identifier;
					dependentEntity1.CreateTimestamp = (DateTime)cmd.Parameters["@p_update_ts_"].Value;
					dependentEntity1.CreateUser = this.user;
				}
				else
				{
					int returnCode = (int)cmd.Parameters["@p_rc_"].Value;
					switch (returnCode)
					{
						case 1: // Update successful.
							saveLogEntry.PostSaveObjectStatus = ObjectStatus.Existing;
							((IEditableObject)dependentEntity1).BeginEdit();
							dependentEntity1.ObjectId = dependentEntity1.ObjectId;
							dependentEntity1.CreateTimestamp = dependentEntity1.CreateTimestamp;
							dependentEntity1.CreateUser = dependentEntity1.CreateUser;
							break;
						case 2: // Collision - object updated by another user.
							throw new SingleCollisionException(RepositoryExceptionMessage.UpdateCollisionDetected, dependentEntity1.EntityClass, dependentEntity1.ObjectId, CollisionType.Update, (string)cmd.Parameters["@p_user_"].Value, (DateTime)cmd.Parameters["@p_update_ts_"].Value);
						case 3: // Collision - object physically deleted by another user.
							throw new SingleCollisionException(RepositoryExceptionMessage.DeleteCollisionDetected, dependentEntity1.EntityClass, dependentEntity1.ObjectId, CollisionType.Delete, null, DateTime.MinValue);
					}
				}
				dependentEntity1.LastUpdateTimestamp = (DateTime)cmd.Parameters["@p_update_ts_"].Value;
				dependentEntity1.LastUpdateUser = this.user;
				if (cmd.Parameters["@p_update_id_"].Value == DBNull.Value)
					dependentEntity1.UpdateId = 0;
				else
					dependentEntity1.UpdateId = (int)cmd.Parameters["@p_update_id_"].Value;
				saveLog.Add(saveLogEntry); // SaveLog takes care of calling EndEdit.
			}
			catch (SingleCollisionException e)
			{
				if (e.Collision.CollisionType == CollisionType.Delete)
					saveLogEntry.PostSaveObjectStatus = ObjectStatus.Deleted;
				else if (e.Collision.CollisionType == CollisionType.Update)
					saveLogEntry.PostSaveObjectStatus = ObjectStatus.Outdated;
				saveLog.Add(saveLogEntry);
				if (e.Collision.CollisionType == CollisionType.Delete)
					saveLog.UpdateSaveLogForCascadeDelete((IEntityObject)dependentEntity1);
				throw;
			}
			catch (SqlException e)
			{
				throw new DALException(RepositoryExceptionMessage.UnexpectedExceptionDetected, e);
			}
			finally
			{
				AfterCommandExecute();
			}

			return insertOperation;
		}

		protected virtual IDependentEntity1 OnDependentEntity1Load(IDependentEntity1 dependentEntity1)
		{
			return dependentEntity1;
		}

		#endregion DependentEntity1 related members.

		#region DependentEntity2 related members.

		public override IDependentEntity2List FindDependentEntity2(int maxCount, SearchCondition searchCondition)
		{
			return this.FindDependentEntity2(maxCount, searchCondition, null, null);
		}

		public override IDependentEntity2List FindDependentEntity2(int maxCount, SearchCondition searchCondition, SortSpecification sortSpecification)
		{
			return this.FindDependentEntity2(maxCount, searchCondition, sortSpecification, null);
		}

		public override IDependentEntity2List FindDependentEntity2(int maxCount, SearchCondition searchCondition, IEntityObjectContext context)
		{
			return this.FindDependentEntity2(maxCount, searchCondition, null, context);
		}

		public override IDependentEntity2List FindDependentEntity2(int maxCount, SearchCondition searchCondition, SortSpecification sortSpecification, IEntityObjectContext context)
		{
			try
			{
				string sql = "SELECT ";
				if (maxCount > -1) sql += "TOP " + maxCount.ToString("d") + " ";
				sql +=
				"[dependent_entity_2_id]," +
				"[dependent_entity_1_id]," +
				"[attr_bool_1]," +
				"[attr_datetime_1]," +
				"[attr_integer_1]," +
				"[attr_string_1]," +
				"[attr_string_2]," +
				"[name]," +
				"[status]," +
				"[create_datetime]," +
				"[create_user]," +
				"[update_datetime]," +
				"[update_id]," +
				"[update_user]" +
				" FROM [dependent_entity_2]";
				SqlCommand cmd = new SqlCommand();
				cmd.CommandTimeout = this.commandTimeout;
				cmd.Connection = this.connection;
				//
				// Add SQL Where criteria if required.
				//
				string whereClause;
				ArrayList whereClauseParameters;
				BuildWhereClause(searchCondition, out whereClause, out whereClauseParameters);
				if (whereClause != null && whereClause != "")
				{
					sql = sql + " WHERE " + whereClause;
					foreach (SqlParameter param in whereClauseParameters)
					{
						cmd.Parameters.Add(param);
					}
				}
				//
				// Add SQL ORDER BY clause if required.
				//
				string orderByClause;
				if (sortSpecification == null)
					orderByClause = BuildOrderByClause(this.dependentEntity2SortSpecification);
				else
					orderByClause = BuildOrderByClause(sortSpecification);
				if (orderByClause != null && orderByClause != "")
					sql += " ORDER BY " + orderByClause;
				//
				// Execute SQL Select command and convert results into a list of DependentEntity2 objects.
				//
				cmd.CommandText = sql;
				cmd.CommandType = CommandType.Text;
				BeforeCommandExecute();
				SqlDataReader sdr = cmd.ExecuteReader();
				IDependentEntity2List dependentEntity2List = (IDependentEntity2List)this.classFactory.GetEntityListObject(EntityClass.DependentEntity2);
				if (sdr.HasRows)
				{
					if (context == null)
					{
						while (sdr.Read())
						{
							dependentEntity2List.Add(CreateDependentEntity2FromSqlDataReader(sdr));
						}
					}
					else
					{
						DependentEntity2Identifier? identifier;
						IEntityObjectContextItem obj;
						while (sdr.Read())
						{
							// Get the primary object id.
							identifier = CreateDependentEntity2IdentifierFromSqlDataReader(sdr, 0);
							if (identifier == null)
							{
								dependentEntity2List.Add(CreateDependentEntity2FromSqlDataReader(sdr));
							}
							else
							{
								if ((obj = context.Get((IIdentifier)identifier.Value)) == null)
									dependentEntity2List.Add(CreateDependentEntity2FromSqlDataReader(sdr));
								else
									dependentEntity2List.Add(obj);
							}
						}
					}
				}
				sdr.Close();

				return dependentEntity2List;
			}
			catch (SqlException e)
			{
				throw new DALException(RepositoryExceptionMessage.UnexpectedExceptionDetected, e);
			}
			finally
			{
				AfterCommandExecute();
			}
		}

		// Parameter propertyName must be a DependentEntity2PropertyName class constant (DependentEntity2BasePropertyName is a subset of DependentEntity2PropertyName).
		public override ArrayList GetAssociatedDependentEntity2Ids(int maxCount, DependentEntity2PropertyName propertyName, object value)
		{
			try
			{
				// Create SQL command.

				string sql = "SELECT ";
				if (maxCount > -1) sql += "TOP " + maxCount.ToString("d") + " ";
				sql +=
				"[dependent_entity_2_id] " +
				"FROM [dependent_entity_2]";

				// Add Where condition.

				SearchCondition searchCondition = new SearchCondition().AppendSearchCondition(propertyName, SearchConditionExpressionOperator.Equal, value);
				string whereClause;
				ArrayList whereClauseParameters;
				BuildWhereClause(searchCondition, out whereClause, out whereClauseParameters);
				sql = sql + " WHERE " + whereClause;
				SqlCommand cmd = new SqlCommand(sql, this.connection);
				cmd.CommandTimeout = this.commandTimeout;
				cmd.CommandType = CommandType.Text;
				foreach (SqlParameter param in whereClauseParameters)
					cmd.Parameters.Add(param);

				// Execute query.

				BeforeCommandExecute();
				SqlDataReader sdr = cmd.ExecuteReader();
				ArrayList dependentEntity2IdentifierList = new ArrayList();
				if (sdr.HasRows)
				{
					while (sdr.Read())
						dependentEntity2IdentifierList.Add(CreateDependentEntity2IdentifierFromSqlDataReader(sdr, 0));
				}
				sdr.Close();

				return dependentEntity2IdentifierList;
			}
			catch (SqlException e)
			{
				throw new DALException(RepositoryExceptionMessage.UnexpectedExceptionDetected, e);
			}
			finally
			{
				AfterCommandExecute();
			}
		}

		public SortSpecification DependentEntity2SortSpecification
		{
			get
			{
				return this.dependentEntity2SortSpecification;
			}
			set
			{
				this.dependentEntity2SortSpecification = value;
			}
		}

		public virtual SortSpecification DependentEntity2DefaultSortSpecification
		{
			get
			{
				return null;
			}
		}

		public override SortSpecification DependentEntity2_ChildOwnedRelationshipEntity1SortSpecification
		{
			get
			{
				return this.dependentEntity2_ChildOwnedRelationshipEntity1SortSpecification;
			}
			set
			{
				this.dependentEntity2_ChildOwnedRelationshipEntity1SortSpecification = value;
			}
		}

		public virtual SortSpecification DependentEntity2_ChildOwnedRelationshipEntity1DefaultSortSpecification
		{
			get
			{
				return null;
			}
		}

		protected override void DeleteDependentEntity2(SearchCondition searchCondition)
		{
			// To avoid accidental deletion of all DependentEntity2 objects, insist on a search condition.
			bool haveSearchCondition;
			if (searchCondition == null)
				haveSearchCondition = false;
			else
				haveSearchCondition = (!searchCondition.IsNullCondition());
			if (!haveSearchCondition) throw new DALException(RepositoryExceptionMessage.NonEmptySearchConditionRequired);

			try
			{
				SqlCommand cmd = new SqlCommand();
				cmd.CommandTimeout = this.commandTimeout;
				cmd.Connection = this.connection;
				string sql = "DELETE FROM [dependent_entity_2]";
				//
				// Add SQL Where criteria if required.
				//
				string sqlWhereConditionText;
				ArrayList sqlWhereConditionParameters;
				BuildWhereClause(searchCondition, out sqlWhereConditionText, out sqlWhereConditionParameters);
				if (sqlWhereConditionText != null && sqlWhereConditionText != "")
				{
					sql = sql + " WHERE " + sqlWhereConditionText;
					foreach (SqlParameter param in sqlWhereConditionParameters)
					{
						cmd.Parameters.Add(param);
					}
				}
				cmd.CommandText = sql;
				cmd.CommandType = CommandType.Text;
				//
				// Execute SQL Delete command.
				//
				BeforeCommandExecute();
				cmd.ExecuteNonQuery();
			}
			catch (SqlException e)
			{
				throw new DALException(RepositoryExceptionMessage.UnexpectedExceptionDetected, e);
			}
			finally
			{
				AfterCommandExecute();
			}
		}


		public override IDependentEntity2 GetDependentEntity2(DependentEntity2Identifier objectId)
		{
			return this.GetDependentEntity2(objectId, null);
		}

		public override IDependentEntity2 GetDependentEntity2(DependentEntity2Identifier objectId, IEntityObjectContext context)
		{
			try
			{
				IDependentEntity2 dependentEntity2 = null;

				if (context == null || (context != null && (dependentEntity2 = (IDependentEntity2)context.Get((IIdentifier)objectId)) == null))
				{
					if (this.dependentEntity2GetCmd == null) CreateDependentEntity2GetCommand();
					SqlCommand cmd = this.dependentEntity2GetCmd;

					// Set input parameters.
					cmd.Parameters["@p_dependent_entity_2_id"].Value = objectId.DependentEntity2Id;

					// Call stored procedure.
					BeforeCommandExecute();
					cmd.ExecuteNonQuery();

					// Process results.

					if ((int)cmd.Parameters["@p_rc_"].Value == 1)
					{
						// Object retrieved successfully.

						dependentEntity2 = (IDependentEntity2)this.classFactory.GetEntityObject(EntityClass.DependentEntity2);
						dependentEntity2.ObjectId = objectId;
						bool foundNullValue;
						// Process foreign key fields associated with the DependentEntity1 owner relationship.
						foundNullValue = (cmd.Parameters["@p_dependent_entity_1_id"].Value == DBNull.Value);
						if (foundNullValue)
						{
							dependentEntity2.ParentOwnerDependentEntity1EntityObjectId = null;
						}
						else
						{
							DependentEntity1Identifier identifier0 = new DependentEntity1Identifier();
							identifier0.DependentEntity1Id = (int)cmd.Parameters["@p_dependent_entity_1_id"].Value;
							dependentEntity2.ParentOwnerDependentEntity1EntityObjectId = identifier0;
						}
						// [attr_bool_1]
						if (cmd.Parameters["@p_attr_bool_1"].Value == DBNull.Value)
						{
							dependentEntity2.AttrBool1 = null;
						}
						else
						{
							dependentEntity2.AttrBool1 = (bool)cmd.Parameters["@p_attr_bool_1"].Value;
						}
						// [attr_datetime_1]
						if (cmd.Parameters["@p_attr_datetime_1"].Value == DBNull.Value)
						{
							dependentEntity2.AttrDatetime1 = null;
						}
						else
						{
							dependentEntity2.AttrDatetime1 = (DateTime)cmd.Parameters["@p_attr_datetime_1"].Value;
						}
						// [attr_integer_1]
						if (cmd.Parameters["@p_attr_integer_1"].Value == DBNull.Value)
						{
							dependentEntity2.AttrInteger1 = null;
						}
						else
						{
							dependentEntity2.AttrInteger1 = (int)cmd.Parameters["@p_attr_integer_1"].Value;
						}
						// [attr_string_1]
						if (cmd.Parameters["@p_attr_string_1"].Value == DBNull.Value)
						{
							dependentEntity2.AttrString1 = null;
						}
						else
						{
							dependentEntity2.AttrString1 = (string)cmd.Parameters["@p_attr_string_1"].Value;
						}
						// [attr_string_2]
						if (cmd.Parameters["@p_attr_string_2"].Value == DBNull.Value)
						{
							dependentEntity2.AttrString2 = null;
						}
						else
						{
							dependentEntity2.AttrString2 = (string)cmd.Parameters["@p_attr_string_2"].Value;
						}
						// [name]
						if (cmd.Parameters["@p_name"].Value == DBNull.Value)
						{
							dependentEntity2.Name = null;
						}
						else
						{
							dependentEntity2.Name = (string)cmd.Parameters["@p_name"].Value;
						}
						// [status]
						if (cmd.Parameters["@p_status"].Value == DBNull.Value)
						{
							dependentEntity2.Status = null;
						}
						else
						{
							dependentEntity2.Status = (string)cmd.Parameters["@p_status"].Value;
						}
						// [create_datetime]
						if (cmd.Parameters["@p_create_datetime"].Value == DBNull.Value)
							dependentEntity2.CreateTimestamp = null;
						else
							dependentEntity2.CreateTimestamp = (DateTime)cmd.Parameters["@p_create_datetime"].Value;
						// [create_user]
						if (cmd.Parameters["@p_create_user"].Value == DBNull.Value)
							dependentEntity2.CreateUser = null;
						else
							dependentEntity2.CreateUser = (string)cmd.Parameters["@p_create_user"].Value;
						// [update_datetime]
						if (cmd.Parameters["@p_update_datetime"].Value == DBNull.Value)
							dependentEntity2.LastUpdateTimestamp = null;
						else
							dependentEntity2.LastUpdateTimestamp = (DateTime)cmd.Parameters["@p_update_datetime"].Value;
						// [update_id]
						if (cmd.Parameters["@p_update_id"].Value == DBNull.Value)
							dependentEntity2.UpdateId = 0;
						else
							dependentEntity2.UpdateId = (int)cmd.Parameters["@p_update_id"].Value;
						// [update_user]
						if (cmd.Parameters["@p_update_user"].Value == DBNull.Value)
							dependentEntity2.LastUpdateUser = null;
						else
							dependentEntity2.LastUpdateUser = (string)cmd.Parameters["@p_update_user"].Value;
						dependentEntity2.ObjectStatus = ObjectStatus.Existing;
						dependentEntity2.HasUncommittedChanges = false;
					}

					// Add newly loaded object to context.
					if (context != null)
						context.Add((IEntityObjectContextItem)dependentEntity2);
				}

				return this.OnDependentEntity2Load(dependentEntity2);
			}
			catch (SqlException e)
			{
				throw new DALException(RepositoryExceptionMessage.UnexpectedExceptionDetected, e);
			}
			finally
			{
				AfterCommandExecute();
			}
		}

		public override byte[] GetDependentEntity2BLOB(DependentEntity2Identifier objectId, int updateId, string columnName)
		{
			return GetDependentEntity2BLOBCore(objectId, updateId, columnName, this.ignoreCollision);
		}

		public override byte[] GetDependentEntity2BLOB(DependentEntity2Identifier objectId, int updateId, string columnName, bool ignoreCollision)
		{
			return GetDependentEntity2BLOBCore(objectId, updateId, columnName, ignoreCollision);
		}

		protected override byte[] GetDependentEntity2BLOBCore(DependentEntity2Identifier objectId, int updateId, string columnName, bool ignoreCollision)
		{
			try
			{
				if (this.dependentEntity2GetBLOBCmd == null)
					CreateDependentEntity2GetBLOBCommand();
				SqlCommand cmd = this.dependentEntity2GetBLOBCmd;

				// Set input parameters.

				cmd.Parameters["@p_dependent_entity_2_id"].Value = objectId.DependentEntity2Id;
				if (ignoreCollision)
					cmd.Parameters["@p_ignore_collision_"].Value = 1;
				else
					cmd.Parameters["@p_ignore_collision_"].Value = 0;
				cmd.Parameters["@p_update_id_"].Value = updateId;
				cmd.Parameters["@p_column_name_"].Value = columnName;

				// Call stored procedure.
				BeforeCommandExecute();
				cmd.ExecuteNonQuery();

				// Process results.

				switch ((int)cmd.Parameters["@p_rc_"].Value)
				{
					case 1: // Fetch successful.
						if (cmd.Parameters["@p_blob_"].Value == DBNull.Value)
							return null;
						else
							return (byte[])cmd.Parameters["@p_blob_"].Value;
					case 2: // Collision - object updated by another user.
						throw new SingleCollisionException(RepositoryExceptionMessage.UpdateCollisionDetected, EntityClass.DependentEntity2, objectId, CollisionType.Update, (string)cmd.Parameters["@p_user_"].Value, (DateTime)cmd.Parameters["@p_update_ts_"].Value);
					case 3: // Collision - object physically deleted by another user.
						throw new SingleCollisionException(RepositoryExceptionMessage.DeleteCollisionDetected, EntityClass.DependentEntity2, objectId, CollisionType.Delete, null, DateTime.MinValue);
					default:
						return null;
				}
			}
			catch (SqlException e)
			{
				throw new DALException(RepositoryExceptionMessage.UnexpectedExceptionDetected, e);
			}
			finally
			{
				AfterCommandExecute();
			}
		}


		public override void DeleteDependentEntity2(IDependentEntity2 dependentEntity2)
		{
			DeleteDependentEntity2Core(dependentEntity2, this.ignoreCollision);
		}

		public override void DeleteDependentEntity2(IDependentEntity2 dependentEntity2, bool ignoreCollision)
		{
			DeleteDependentEntity2Core(dependentEntity2, ignoreCollision);
		}

		protected override void DeleteDependentEntity2Core(IDependentEntity2 dependentEntity2, bool ignoreCollision)
		{
			// When transaction support is added, ApplySaveLog must not be called if an exception is encountered.
			SaveLog saveLog = new SaveLog();
			try
			{
				DeleteDependentEntity2Core(dependentEntity2, ignoreCollision, saveLog);
				saveLog.ApplySaveLog();
			}
			catch (Exception)
			{
				// Still call ApplySaveLog because no support for transaction/rollback yet.
				saveLog.ApplySaveLog();
				throw;
			}
		}

		// Because cascade delete operations are handled at the DB level, this implementation of this function is trivial.
		protected override void DeleteDependentEntity2Core(IDependentEntity2 dependentEntity2, bool ignoreCollision, SaveLog saveLog)
		{
			DeleteDependentEntity2EntityObjectCore(dependentEntity2, ignoreCollision, saveLog);
		}

		protected override void DeleteDependentEntity2EntityObjectCore(IDependentEntity2 dependentEntity2, bool ignoreCollision, SaveLog saveLog)
		{
			SaveLogEntry saveLogEntry = new SaveLogEntry();
			// These saveLogEntry assignments must occur here so that they are set if an exception occurs.
			saveLogEntry.EntityObject = dependentEntity2;
			saveLogEntry.PreSaveObjectStatus = dependentEntity2.ObjectStatus;
			try
			{
				saveLogEntry.RepositoryUpdateOperation = RepositoryUpdateOperation.Delete;

				DeleteDependentEntity2((DependentEntity2Identifier)dependentEntity2.ObjectId, dependentEntity2.UpdateId, ignoreCollision);

				saveLogEntry.PostSaveObjectStatus = ObjectStatus.Deleted;
				saveLog.Add(saveLogEntry);
				// Add SaveLog entries for in-memory objects owned by dependentEntity2 that must have been cascade deleted by the repository.
				saveLog.UpdateSaveLogForCascadeDelete((IEntityObject)dependentEntity2);
			}
			catch (SingleCollisionException e)
			{
				// Update the object's status to reflect the collision.
				if (e.Collision.CollisionType == CollisionType.Delete)
					// Collision - object physically deleted by another user.
					saveLogEntry.PostSaveObjectStatus = ObjectStatus.Deleted;
				else if (e.Collision.CollisionType == CollisionType.Update)
					// Collision - object updated by another user.
					saveLogEntry.PostSaveObjectStatus = ObjectStatus.Outdated;
				saveLog.Add(saveLogEntry);
				if (e.Collision.CollisionType == CollisionType.Delete)
				{
					saveLog.UpdateSaveLogForCascadeDelete((IEntityObject)dependentEntity2);
				}
				// Rethrow the collision exception.
				throw;
			}
		}

		public override void DeleteDependentEntity2(DependentEntity2Identifier objectId, int updateId)
		{
			DeleteDependentEntity2Core(objectId, updateId, this.ignoreCollision);
		}

		public override void DeleteDependentEntity2(DependentEntity2Identifier objectId, int updateId, bool ignoreCollision)
		{
			DeleteDependentEntity2Core(objectId, updateId, ignoreCollision);
		}

		protected override void DeleteDependentEntity2Core(DependentEntity2Identifier objectId, int updateId, bool ignoreCollision)
		{
			try
			{
				if (this.dependentEntity2DeleteCmd == null) CreateDependentEntity2DeleteCommand();
				SqlCommand cmd = this.dependentEntity2DeleteCmd;

				// Set input parameters specific to the delete operation.

				cmd.Parameters["@p_dependent_entity_2_id"].Value = objectId.DependentEntity2Id;
				if (ignoreCollision)
					cmd.Parameters["@p_ignore_collision_"].Value = 1;
				else
					cmd.Parameters["@p_ignore_collision_"].Value = 0;
				cmd.Parameters["@p_update_id_"].Value = updateId;

				// Call stored procedure.
				BeforeCommandExecute();
				cmd.ExecuteNonQuery();

				// Process results.

				switch ((int)cmd.Parameters["@p_rc_"].Value)
				{
					case 1: // Update successful.
						break;
					case 2: // Collision - object updated by another user.
						throw new SingleCollisionException(RepositoryExceptionMessage.UpdateCollisionDetected, EntityClass.DependentEntity2, objectId, CollisionType.Update, (string)cmd.Parameters["@p_user_"].Value, (DateTime)cmd.Parameters["@p_update_ts_"].Value);
					case 3: // Collision - object physically deleted by another user.
						throw new SingleCollisionException(RepositoryExceptionMessage.DeleteCollisionDetected, EntityClass.DependentEntity2, objectId, CollisionType.Delete, null, DateTime.MinValue);
				}
			}
			catch (SqlException e)
			{
				throw new DALException(RepositoryExceptionMessage.UnexpectedExceptionDetected, e);
			}
			finally
			{
				AfterCommandExecute();
			}
		}


		public override void SaveDependentEntity2(IDependentEntity2 dependentEntity2)
		{
			SaveDependentEntity2Core(dependentEntity2, this.ignoreCollision);
		}

		public override void SaveDependentEntity2(IDependentEntity2 dependentEntity2, bool ignoreCollision)
		{
			SaveDependentEntity2Core(dependentEntity2, ignoreCollision);
		}

		protected override void SaveDependentEntity2Core(IDependentEntity2 dependentEntity2, bool ignoreCollision)
		{
			// When transaction support is added, ApplySaveLog must not be called if an exception is encountered.
			SaveLog saveLog = new SaveLog();
			try
			{
				SaveDependentEntity2Core(dependentEntity2, ignoreCollision, saveLog);
				saveLog.ApplySaveLog();
			}
			catch (Exception)
			{
				// Still call ApplySaveLog because no support for transaction/rollback yet.
				saveLog.ApplySaveLog();
				// Reverse the commit state set by ApplySaveLog.
				dependentEntity2.HasUncommittedChanges = true; // This line ensures that errors in saving dependent entities don't result in the parent being marked as uncommitted (because it isn't).
				throw;
			}
		}

		// The core function for saving a specific DependentEntity2 instance as well as related entity objects.
		// If an object is marked for deletion, this function calls DeleteDependentEntity2Core.
		// This function must NEVER update any properties of the entity object (dependentEntity2).
		// Such updates must be cached in saveLog and applied by the caller depending upon whether or not an exception occurred and if the update is part of a transaction.
		protected override void SaveDependentEntity2Core(IDependentEntity2 dependentEntity2, bool ignoreCollision, SaveLog saveLog)
		{
			if (dependentEntity2.MarkedForDeletion)
			{
				// Database level cascade delete will take care of whatever dependent and relation entities are associated with DependentEntity2.
				DeleteDependentEntity2Core(dependentEntity2, ignoreCollision, saveLog);
			}
			else
			{
				#region Entity Object

				bool insertOperation = SaveDependentEntity2EntityObjectCore(dependentEntity2, ignoreCollision, saveLog);

				#endregion Entity Object

				#region Owned Child Entity Objects

				// Save child RelationshipEntity1 objects.
				// Relationship has a cardinality of many.
				switch (dependentEntity2.ChildOwnedRelationshipEntity1ListLoadStatus)
				{
					case LoadStatus.Full:
						// The content of the child collection is what the repository should be synchronized with.
						if (dependentEntity2.HasChildOwnedRelationshipEntity1Objects(false))
						{
							if (insertOperation)
							{
								// This is the first time the parent DependentEntity2 object has been saved.
								// Therefore, it cannot have any child RelationshipEntity1 objects in the repository.
								// Therefore, it is not necessary to check the repository to determine if existing child objects need to be removed because they are not associated with the in-memory copy of the parent object.
								this.Save((IList)dependentEntity2.ChildOwnedRelationshipEntity1List, false);
							}
							else
							{
								// Since the parent DependentEntity2 object existed in the repository prior to this call to save, it is possible that there already exist child RelationshipEntity1 objects in the repository.
								// The repository set of child RelationshipEntity1 objects has to be synchronized with the in-memory set.

								// Get a list of object ids of RelationshipEntity1 objects associated with the database copy of DependentEntity2.
								ArrayList relationshipEntity1Ids = GetAssociatedRelationshipEntity1Ids(-1, RelationshipEntity1PropertyName.ParentOwnerDependentEntity2EntityObjectId, dependentEntity2.ObjectId);

								// Remove from the list ids of RelationshipEntity1 objects that are related to the in-memory copy of DependentEntity2.
								// After this is done, the list will contain ids of those RelationshipEntity1 objects that must be deleted from the repository since they are no longer related to the in-memory copy of DependentEntity2.
								relationshipEntity1Ids.Sort();
								int index;
								foreach (IRelationshipEntity1 childRelationshipEntity1 in dependentEntity2.ChildOwnedRelationshipEntity1List)
								{
									index = relationshipEntity1Ids.BinarySearch(childRelationshipEntity1.ObjectId);
									if (index >= 0) relationshipEntity1Ids.RemoveAt(index);
								}

								// The remaining ids in relationshipEntity1Ids collection identify the RelationshipEntity1 objects to be deleted from the database, since they are no longer related to the in-memory copy of DependentEntity2.
								for (index = 0; index < relationshipEntity1Ids.Count; ++index)
									// The following delete call sets ignoreCollision = true.
									// This is because update ids were not loaded along with the object ids.
									// Without update ids, collision detection isn't possible.
									// There is no need for collision detection at this point anyway, because the parent DependentEntity2 object
									// has passed its collision test.
									DeleteRelationshipEntity1Core((RelationshipEntity1Identifier)relationshipEntity1Ids[index], 0, true); // If ignoreCollision = true, updateId is ignored.

								// Save the child entity objects.
								this.Save((IList)dependentEntity2.ChildOwnedRelationshipEntity1List, true);
							} // if (insertOperation)
						}
						else
						{
							// The LoadStatus is Full and the child collecton is empty.
							// If the parent DependentEntity2 object existed in the repository prior to this save, there is a chance the repository copy has child RelationshipEntity1 objects that must be deleted.
							if (!insertOperation)
							{
								// Delete any child RelationshipEntity1 object that may exist in the repository.
								// The most efficient way to synchronize the database is to simply issue a bulk erase call to remove all associated RelationshipEntity1 objects from the database.
								this.DeleteRelationshipEntity1(new SearchCondition().AppendSearchCondition(RelationshipEntity1PropertyName.ParentOwnerDependentEntity2EntityObjectId, SearchConditionExpressionOperator.Equal, dependentEntity2.ObjectId));
							}
						} // if (dependentEntity2.HasChildOwnedRelationshipEntity1Objects(false))
						break;
					case LoadStatus.Partial:
						// Update the set of child RelationshipEntity1 objects in the repository to be the union of the existing child objects in the repository and the in-memory child objects.
						if (dependentEntity2.HasChildOwnedRelationshipEntity1Objects(false))
							this.Save((IList)dependentEntity2.ChildOwnedRelationshipEntity1List, true);
						break;
					case LoadStatus.NotLoaded:
						// In-memory copy of DependentEntity2 has the same child RelationshipEntity1 objects as the respository counterpart does.
						// Therefore, no repository update is required.
						break;
				}


				#endregion Owned Child Entity Objects

			} // if (dependentEntity2.MarkedForDeletion)
		}

		// The core function for saving a specific DependentEntity2 object.
		// It does not handle deletes (if the entity is marked for deletion) nor updating of related entity objects.
		// This function must NEVER update any properties of the entity object (dependentEntity2).
		// Such updates must be cached in saveLog and applied by the caller depending upon whether or not an exception occurred and if the update is part of a transaction.
		protected override bool SaveDependentEntity2EntityObjectCore(IDependentEntity2 dependentEntity2, bool ignoreCollision, SaveLog saveLog)
		{
			bool insertOperation;

			SaveLogEntry saveLogEntry = new SaveLogEntry();
			// These saveLogEntry assignments must occur here so that they are set if an exception occurs.
			saveLogEntry.EntityObject = dependentEntity2;
			saveLogEntry.PreSaveObjectStatus = dependentEntity2.ObjectStatus;

			try
			{
				insertOperation = !dependentEntity2.ObjectId.HasValue;
				SqlCommand cmd;

				if (insertOperation)
				{
					// Have a new DependentEntity2 object to save.

					saveLogEntry.RepositoryUpdateOperation = RepositoryUpdateOperation.Insert;

					if (this.dependentEntity2InsertCmd == null) CreateDependentEntity2InsertCommand();
					cmd = this.dependentEntity2InsertCmd;
				}
				else
				{
					// Have a previously saved DependentEntity2 object to save.

					saveLogEntry.RepositoryUpdateOperation = RepositoryUpdateOperation.Update;

					if (this.dependentEntity2UpdateCmd == null) CreateDependentEntity2UpdateCommand();
					cmd = this.dependentEntity2UpdateCmd;

					// Set input parameters specific to the update operation.

					cmd.Parameters["@p_dependent_entity_2_id"].Value = dependentEntity2.DependentEntity2Id.Value;
					if (ignoreCollision)
						cmd.Parameters["@p_ignore_collision_"].Value = 1;
					else
						cmd.Parameters["@p_ignore_collision_"].Value = 0;
					cmd.Parameters["@p_update_id_"].Value = dependentEntity2.UpdateId;
				}

				// Set input parameters common to both insert and update operations.

				// [dependent_entity_1_id]
				if (dependentEntity2.DependentEntity1Id.HasValue)
					cmd.Parameters["@p_dependent_entity_1_id"].Value = dependentEntity2.DependentEntity1Id.Value;
				else
					cmd.Parameters["@p_dependent_entity_1_id"].Value = DBNull.Value;
				// [attr_bool_1]
				cmd.Parameters["@p_attr_bool_1"].Value = dependentEntity2.AttrBool1_DBObjectValue;
				// [attr_datetime_1]
				cmd.Parameters["@p_attr_datetime_1"].Value = dependentEntity2.AttrDatetime1_DBObjectValue;
				// [attr_integer_1]
				cmd.Parameters["@p_attr_integer_1"].Value = dependentEntity2.AttrInteger1_DBObjectValue;
				// [attr_string_1]
				cmd.Parameters["@p_attr_string_1"].Value = dependentEntity2.AttrString1_DBObjectValue;
				// [attr_string_2]
				cmd.Parameters["@p_attr_string_2"].Value = dependentEntity2.AttrString2_DBObjectValue;
				// [name]
				cmd.Parameters["@p_name"].Value = dependentEntity2.Name_DBObjectValue;
				// [status]
				cmd.Parameters["@p_status"].Value = dependentEntity2.Status_DBObjectValue;
				cmd.Parameters["@p_user_"].Value = this.user;

				// Call stored procedure.
				BeforeCommandExecute();
				cmd.ExecuteNonQuery();

				// Process results.
				if (insertOperation)
				{
					saveLogEntry.PostSaveObjectStatus = ObjectStatus.Existing;
					((IEditableObject)dependentEntity2).BeginEdit();
					DependentEntity2Identifier identifier = new DependentEntity2Identifier();
					identifier.DependentEntity2Id = (int)cmd.Parameters["@p_dependent_entity_2_id"].Value;
					dependentEntity2.ObjectId = identifier;
					dependentEntity2.CreateTimestamp = (DateTime)cmd.Parameters["@p_update_ts_"].Value;
					dependentEntity2.CreateUser = this.user;
				}
				else
				{
					int returnCode = (int)cmd.Parameters["@p_rc_"].Value;
					switch (returnCode)
					{
						case 1: // Update successful.
							saveLogEntry.PostSaveObjectStatus = ObjectStatus.Existing;
							((IEditableObject)dependentEntity2).BeginEdit();
							dependentEntity2.ObjectId = dependentEntity2.ObjectId;
							dependentEntity2.CreateTimestamp = dependentEntity2.CreateTimestamp;
							dependentEntity2.CreateUser = dependentEntity2.CreateUser;
							break;
						case 2: // Collision - object updated by another user.
							throw new SingleCollisionException(RepositoryExceptionMessage.UpdateCollisionDetected, dependentEntity2.EntityClass, dependentEntity2.ObjectId, CollisionType.Update, (string)cmd.Parameters["@p_user_"].Value, (DateTime)cmd.Parameters["@p_update_ts_"].Value);
						case 3: // Collision - object physically deleted by another user.
							throw new SingleCollisionException(RepositoryExceptionMessage.DeleteCollisionDetected, dependentEntity2.EntityClass, dependentEntity2.ObjectId, CollisionType.Delete, null, DateTime.MinValue);
					}
				}
				dependentEntity2.LastUpdateTimestamp = (DateTime)cmd.Parameters["@p_update_ts_"].Value;
				dependentEntity2.LastUpdateUser = this.user;
				if (cmd.Parameters["@p_update_id_"].Value == DBNull.Value)
					dependentEntity2.UpdateId = 0;
				else
					dependentEntity2.UpdateId = (int)cmd.Parameters["@p_update_id_"].Value;
				saveLog.Add(saveLogEntry); // SaveLog takes care of calling EndEdit.
			}
			catch (SingleCollisionException e)
			{
				if (e.Collision.CollisionType == CollisionType.Delete)
					saveLogEntry.PostSaveObjectStatus = ObjectStatus.Deleted;
				else if (e.Collision.CollisionType == CollisionType.Update)
					saveLogEntry.PostSaveObjectStatus = ObjectStatus.Outdated;
				saveLog.Add(saveLogEntry);
				if (e.Collision.CollisionType == CollisionType.Delete)
					saveLog.UpdateSaveLogForCascadeDelete((IEntityObject)dependentEntity2);
				throw;
			}
			catch (SqlException e)
			{
				throw new DALException(RepositoryExceptionMessage.UnexpectedExceptionDetected, e);
			}
			finally
			{
				AfterCommandExecute();
			}

			return insertOperation;
		}

		protected virtual IDependentEntity2 OnDependentEntity2Load(IDependentEntity2 dependentEntity2)
		{
			return dependentEntity2;
		}

		#endregion DependentEntity2 related members.

		#region IndependentEntity1 related members.

		public override IIndependentEntity1List FindIndependentEntity1(int maxCount, SearchCondition searchCondition)
		{
			return this.FindIndependentEntity1(maxCount, searchCondition, null, null);
		}

		public override IIndependentEntity1List FindIndependentEntity1(int maxCount, SearchCondition searchCondition, SortSpecification sortSpecification)
		{
			return this.FindIndependentEntity1(maxCount, searchCondition, sortSpecification, null);
		}

		public override IIndependentEntity1List FindIndependentEntity1(int maxCount, SearchCondition searchCondition, IEntityObjectContext context)
		{
			return this.FindIndependentEntity1(maxCount, searchCondition, null, context);
		}

		public override IIndependentEntity1List FindIndependentEntity1(int maxCount, SearchCondition searchCondition, SortSpecification sortSpecification, IEntityObjectContext context)
		{
			try
			{
				string sql = "SELECT ";
				if (maxCount > -1) sql += "TOP " + maxCount.ToString("d") + " ";
				sql +=
				"[independent_entity_1_id]," +
				"[attr_bool_1]," +
				"[attr_datetime_1]," +
				"[attr_integer_1]," +
				"[attr_string_1]," +
				"[attr_string_2]," +
				"[name]," +
				"[status]," +
				"[create_datetime]," +
				"[create_user]," +
				"[update_datetime]," +
				"[update_id]," +
				"[update_user]" +
				" FROM [independent_entity_1]";
				SqlCommand cmd = new SqlCommand();
				cmd.CommandTimeout = this.commandTimeout;
				cmd.Connection = this.connection;
				//
				// Add SQL Where criteria if required.
				//
				string whereClause;
				ArrayList whereClauseParameters;
				BuildWhereClause(searchCondition, out whereClause, out whereClauseParameters);
				if (whereClause != null && whereClause != "")
				{
					sql = sql + " WHERE " + whereClause;
					foreach (SqlParameter param in whereClauseParameters)
					{
						cmd.Parameters.Add(param);
					}
				}
				//
				// Add SQL ORDER BY clause if required.
				//
				string orderByClause;
				if (sortSpecification == null)
					orderByClause = BuildOrderByClause(this.independentEntity1SortSpecification);
				else
					orderByClause = BuildOrderByClause(sortSpecification);
				if (orderByClause != null && orderByClause != "")
					sql += " ORDER BY " + orderByClause;
				//
				// Execute SQL Select command and convert results into a list of IndependentEntity1 objects.
				//
				cmd.CommandText = sql;
				cmd.CommandType = CommandType.Text;
				BeforeCommandExecute();
				SqlDataReader sdr = cmd.ExecuteReader();
				IIndependentEntity1List independentEntity1List = (IIndependentEntity1List)this.classFactory.GetEntityListObject(EntityClass.IndependentEntity1);
				if (sdr.HasRows)
				{
					if (context == null)
					{
						while (sdr.Read())
						{
							independentEntity1List.Add(CreateIndependentEntity1FromSqlDataReader(sdr));
						}
					}
					else
					{
						IndependentEntity1Identifier? identifier;
						IEntityObjectContextItem obj;
						while (sdr.Read())
						{
							// Get the primary object id.
							identifier = CreateIndependentEntity1IdentifierFromSqlDataReader(sdr, 0);
							if (identifier == null)
							{
								independentEntity1List.Add(CreateIndependentEntity1FromSqlDataReader(sdr));
							}
							else
							{
								if ((obj = context.Get((IIdentifier)identifier.Value)) == null)
									independentEntity1List.Add(CreateIndependentEntity1FromSqlDataReader(sdr));
								else
									independentEntity1List.Add(obj);
							}
						}
					}
				}
				sdr.Close();

				return independentEntity1List;
			}
			catch (SqlException e)
			{
				throw new DALException(RepositoryExceptionMessage.UnexpectedExceptionDetected, e);
			}
			finally
			{
				AfterCommandExecute();
			}
		}

		// Parameter propertyName must be a IndependentEntity1PropertyName class constant (IndependentEntity1BasePropertyName is a subset of IndependentEntity1PropertyName).
		public override ArrayList GetAssociatedIndependentEntity1Ids(int maxCount, IndependentEntity1PropertyName propertyName, object value)
		{
			try
			{
				// Create SQL command.

				string sql = "SELECT ";
				if (maxCount > -1) sql += "TOP " + maxCount.ToString("d") + " ";
				sql +=
				"[independent_entity_1_id] " +
				"FROM [independent_entity_1]";

				// Add Where condition.

				SearchCondition searchCondition = new SearchCondition().AppendSearchCondition(propertyName, SearchConditionExpressionOperator.Equal, value);
				string whereClause;
				ArrayList whereClauseParameters;
				BuildWhereClause(searchCondition, out whereClause, out whereClauseParameters);
				sql = sql + " WHERE " + whereClause;
				SqlCommand cmd = new SqlCommand(sql, this.connection);
				cmd.CommandTimeout = this.commandTimeout;
				cmd.CommandType = CommandType.Text;
				foreach (SqlParameter param in whereClauseParameters)
					cmd.Parameters.Add(param);

				// Execute query.

				BeforeCommandExecute();
				SqlDataReader sdr = cmd.ExecuteReader();
				ArrayList independentEntity1IdentifierList = new ArrayList();
				if (sdr.HasRows)
				{
					while (sdr.Read())
						independentEntity1IdentifierList.Add(CreateIndependentEntity1IdentifierFromSqlDataReader(sdr, 0));
				}
				sdr.Close();

				return independentEntity1IdentifierList;
			}
			catch (SqlException e)
			{
				throw new DALException(RepositoryExceptionMessage.UnexpectedExceptionDetected, e);
			}
			finally
			{
				AfterCommandExecute();
			}
		}

		public SortSpecification IndependentEntity1SortSpecification
		{
			get
			{
				return this.independentEntity1SortSpecification;
			}
			set
			{
				this.independentEntity1SortSpecification = value;
			}
		}

		public virtual SortSpecification IndependentEntity1DefaultSortSpecification
		{
			get
			{
				return null;
			}
		}

		public override SortSpecification IndependentEntity1_ChildOwnedDependentEntity1SortSpecification
		{
			get
			{
				return this.independentEntity1_ChildOwnedDependentEntity1SortSpecification;
			}
			set
			{
				this.independentEntity1_ChildOwnedDependentEntity1SortSpecification = value;
			}
		}

		public virtual SortSpecification IndependentEntity1_ChildOwnedDependentEntity1DefaultSortSpecification
		{
			get
			{
				return null;
			}
		}

		protected override void DeleteIndependentEntity1(SearchCondition searchCondition)
		{
			// To avoid accidental deletion of all IndependentEntity1 objects, insist on a search condition.
			bool haveSearchCondition;
			if (searchCondition == null)
				haveSearchCondition = false;
			else
				haveSearchCondition = (!searchCondition.IsNullCondition());
			if (!haveSearchCondition) throw new DALException(RepositoryExceptionMessage.NonEmptySearchConditionRequired);

			try
			{
				SqlCommand cmd = new SqlCommand();
				cmd.CommandTimeout = this.commandTimeout;
				cmd.Connection = this.connection;
				string sql = "DELETE FROM [independent_entity_1]";
				//
				// Add SQL Where criteria if required.
				//
				string sqlWhereConditionText;
				ArrayList sqlWhereConditionParameters;
				BuildWhereClause(searchCondition, out sqlWhereConditionText, out sqlWhereConditionParameters);
				if (sqlWhereConditionText != null && sqlWhereConditionText != "")
				{
					sql = sql + " WHERE " + sqlWhereConditionText;
					foreach (SqlParameter param in sqlWhereConditionParameters)
					{
						cmd.Parameters.Add(param);
					}
				}
				cmd.CommandText = sql;
				cmd.CommandType = CommandType.Text;
				//
				// Execute SQL Delete command.
				//
				BeforeCommandExecute();
				cmd.ExecuteNonQuery();
			}
			catch (SqlException e)
			{
				throw new DALException(RepositoryExceptionMessage.UnexpectedExceptionDetected, e);
			}
			finally
			{
				AfterCommandExecute();
			}
		}


		public override IIndependentEntity1 GetIndependentEntity1(IndependentEntity1Identifier objectId)
		{
			return this.GetIndependentEntity1(objectId, null);
		}

		public override IIndependentEntity1 GetIndependentEntity1(IndependentEntity1Identifier objectId, IEntityObjectContext context)
		{
			try
			{
				IIndependentEntity1 independentEntity1 = null;

				if (context == null || (context != null && (independentEntity1 = (IIndependentEntity1)context.Get((IIdentifier)objectId)) == null))
				{
					if (this.independentEntity1GetCmd == null) CreateIndependentEntity1GetCommand();
					SqlCommand cmd = this.independentEntity1GetCmd;

					// Set input parameters.
					cmd.Parameters["@p_independent_entity_1_id"].Value = objectId.IndependentEntity1Id;

					// Call stored procedure.
					BeforeCommandExecute();
					cmd.ExecuteNonQuery();

					// Process results.

					if ((int)cmd.Parameters["@p_rc_"].Value == 1)
					{
						// Object retrieved successfully.

						independentEntity1 = (IIndependentEntity1)this.classFactory.GetEntityObject(EntityClass.IndependentEntity1);
						independentEntity1.ObjectId = objectId;
						// [attr_bool_1]
						if (cmd.Parameters["@p_attr_bool_1"].Value == DBNull.Value)
						{
							independentEntity1.AttrBool1 = null;
						}
						else
						{
							independentEntity1.AttrBool1 = (bool)cmd.Parameters["@p_attr_bool_1"].Value;
						}
						// [attr_datetime_1]
						if (cmd.Parameters["@p_attr_datetime_1"].Value == DBNull.Value)
						{
							independentEntity1.AttrDatetime1 = null;
						}
						else
						{
							independentEntity1.AttrDatetime1 = (DateTime)cmd.Parameters["@p_attr_datetime_1"].Value;
						}
						// [attr_integer_1]
						if (cmd.Parameters["@p_attr_integer_1"].Value == DBNull.Value)
						{
							independentEntity1.AttrInteger1 = null;
						}
						else
						{
							independentEntity1.AttrInteger1 = (int)cmd.Parameters["@p_attr_integer_1"].Value;
						}
						// [attr_string_1]
						if (cmd.Parameters["@p_attr_string_1"].Value == DBNull.Value)
						{
							independentEntity1.AttrString1 = null;
						}
						else
						{
							independentEntity1.AttrString1 = (string)cmd.Parameters["@p_attr_string_1"].Value;
						}
						// [attr_string_2]
						if (cmd.Parameters["@p_attr_string_2"].Value == DBNull.Value)
						{
							independentEntity1.AttrString2 = null;
						}
						else
						{
							independentEntity1.AttrString2 = (string)cmd.Parameters["@p_attr_string_2"].Value;
						}
						// [name]
						if (cmd.Parameters["@p_name"].Value == DBNull.Value)
						{
							independentEntity1.Name = null;
						}
						else
						{
							independentEntity1.Name = (string)cmd.Parameters["@p_name"].Value;
						}
						// [status]
						if (cmd.Parameters["@p_status"].Value == DBNull.Value)
						{
							independentEntity1.Status = null;
						}
						else
						{
							independentEntity1.Status = (string)cmd.Parameters["@p_status"].Value;
						}
						// [create_datetime]
						if (cmd.Parameters["@p_create_datetime"].Value == DBNull.Value)
							independentEntity1.CreateTimestamp = null;
						else
							independentEntity1.CreateTimestamp = (DateTime)cmd.Parameters["@p_create_datetime"].Value;
						// [create_user]
						if (cmd.Parameters["@p_create_user"].Value == DBNull.Value)
							independentEntity1.CreateUser = null;
						else
							independentEntity1.CreateUser = (string)cmd.Parameters["@p_create_user"].Value;
						// [update_datetime]
						if (cmd.Parameters["@p_update_datetime"].Value == DBNull.Value)
							independentEntity1.LastUpdateTimestamp = null;
						else
							independentEntity1.LastUpdateTimestamp = (DateTime)cmd.Parameters["@p_update_datetime"].Value;
						// [update_id]
						if (cmd.Parameters["@p_update_id"].Value == DBNull.Value)
							independentEntity1.UpdateId = 0;
						else
							independentEntity1.UpdateId = (int)cmd.Parameters["@p_update_id"].Value;
						// [update_user]
						if (cmd.Parameters["@p_update_user"].Value == DBNull.Value)
							independentEntity1.LastUpdateUser = null;
						else
							independentEntity1.LastUpdateUser = (string)cmd.Parameters["@p_update_user"].Value;
						independentEntity1.ObjectStatus = ObjectStatus.Existing;
						independentEntity1.HasUncommittedChanges = false;
					}

					// Add newly loaded object to context.
					if (context != null)
						context.Add((IEntityObjectContextItem)independentEntity1);
				}

				return this.OnIndependentEntity1Load(independentEntity1);
			}
			catch (SqlException e)
			{
				throw new DALException(RepositoryExceptionMessage.UnexpectedExceptionDetected, e);
			}
			finally
			{
				AfterCommandExecute();
			}
		}

		public override byte[] GetIndependentEntity1BLOB(IndependentEntity1Identifier objectId, int updateId, string columnName)
		{
			return GetIndependentEntity1BLOBCore(objectId, updateId, columnName, this.ignoreCollision);
		}

		public override byte[] GetIndependentEntity1BLOB(IndependentEntity1Identifier objectId, int updateId, string columnName, bool ignoreCollision)
		{
			return GetIndependentEntity1BLOBCore(objectId, updateId, columnName, ignoreCollision);
		}

		protected override byte[] GetIndependentEntity1BLOBCore(IndependentEntity1Identifier objectId, int updateId, string columnName, bool ignoreCollision)
		{
			try
			{
				if (this.independentEntity1GetBLOBCmd == null)
					CreateIndependentEntity1GetBLOBCommand();
				SqlCommand cmd = this.independentEntity1GetBLOBCmd;

				// Set input parameters.

				cmd.Parameters["@p_independent_entity_1_id"].Value = objectId.IndependentEntity1Id;
				if (ignoreCollision)
					cmd.Parameters["@p_ignore_collision_"].Value = 1;
				else
					cmd.Parameters["@p_ignore_collision_"].Value = 0;
				cmd.Parameters["@p_update_id_"].Value = updateId;
				cmd.Parameters["@p_column_name_"].Value = columnName;

				// Call stored procedure.
				BeforeCommandExecute();
				cmd.ExecuteNonQuery();

				// Process results.

				switch ((int)cmd.Parameters["@p_rc_"].Value)
				{
					case 1: // Fetch successful.
						if (cmd.Parameters["@p_blob_"].Value == DBNull.Value)
							return null;
						else
							return (byte[])cmd.Parameters["@p_blob_"].Value;
					case 2: // Collision - object updated by another user.
						throw new SingleCollisionException(RepositoryExceptionMessage.UpdateCollisionDetected, EntityClass.IndependentEntity1, objectId, CollisionType.Update, (string)cmd.Parameters["@p_user_"].Value, (DateTime)cmd.Parameters["@p_update_ts_"].Value);
					case 3: // Collision - object physically deleted by another user.
						throw new SingleCollisionException(RepositoryExceptionMessage.DeleteCollisionDetected, EntityClass.IndependentEntity1, objectId, CollisionType.Delete, null, DateTime.MinValue);
					default:
						return null;
				}
			}
			catch (SqlException e)
			{
				throw new DALException(RepositoryExceptionMessage.UnexpectedExceptionDetected, e);
			}
			finally
			{
				AfterCommandExecute();
			}
		}


		public override void DeleteIndependentEntity1(IIndependentEntity1 independentEntity1)
		{
			DeleteIndependentEntity1Core(independentEntity1, this.ignoreCollision);
		}

		public override void DeleteIndependentEntity1(IIndependentEntity1 independentEntity1, bool ignoreCollision)
		{
			DeleteIndependentEntity1Core(independentEntity1, ignoreCollision);
		}

		protected override void DeleteIndependentEntity1Core(IIndependentEntity1 independentEntity1, bool ignoreCollision)
		{
			// When transaction support is added, ApplySaveLog must not be called if an exception is encountered.
			SaveLog saveLog = new SaveLog();
			try
			{
				DeleteIndependentEntity1Core(independentEntity1, ignoreCollision, saveLog);
				saveLog.ApplySaveLog();
			}
			catch (Exception)
			{
				// Still call ApplySaveLog because no support for transaction/rollback yet.
				saveLog.ApplySaveLog();
				throw;
			}
		}

		// Because cascade delete operations are handled at the DB level, this implementation of this function is trivial.
		protected override void DeleteIndependentEntity1Core(IIndependentEntity1 independentEntity1, bool ignoreCollision, SaveLog saveLog)
		{
			DeleteIndependentEntity1EntityObjectCore(independentEntity1, ignoreCollision, saveLog);
		}

		protected override void DeleteIndependentEntity1EntityObjectCore(IIndependentEntity1 independentEntity1, bool ignoreCollision, SaveLog saveLog)
		{
			SaveLogEntry saveLogEntry = new SaveLogEntry();
			// These saveLogEntry assignments must occur here so that they are set if an exception occurs.
			saveLogEntry.EntityObject = independentEntity1;
			saveLogEntry.PreSaveObjectStatus = independentEntity1.ObjectStatus;
			try
			{
				saveLogEntry.RepositoryUpdateOperation = RepositoryUpdateOperation.Delete;

				DeleteIndependentEntity1((IndependentEntity1Identifier)independentEntity1.ObjectId, independentEntity1.UpdateId, ignoreCollision);

				saveLogEntry.PostSaveObjectStatus = ObjectStatus.Deleted;
				saveLog.Add(saveLogEntry);
				// Add SaveLog entries for in-memory objects owned by independentEntity1 that must have been cascade deleted by the repository.
				saveLog.UpdateSaveLogForCascadeDelete((IEntityObject)independentEntity1);
			}
			catch (SingleCollisionException e)
			{
				// Update the object's status to reflect the collision.
				if (e.Collision.CollisionType == CollisionType.Delete)
					// Collision - object physically deleted by another user.
					saveLogEntry.PostSaveObjectStatus = ObjectStatus.Deleted;
				else if (e.Collision.CollisionType == CollisionType.Update)
					// Collision - object updated by another user.
					saveLogEntry.PostSaveObjectStatus = ObjectStatus.Outdated;
				saveLog.Add(saveLogEntry);
				if (e.Collision.CollisionType == CollisionType.Delete)
				{
					saveLog.UpdateSaveLogForCascadeDelete((IEntityObject)independentEntity1);
				}
				// Rethrow the collision exception.
				throw;
			}
		}

		public override void DeleteIndependentEntity1(IndependentEntity1Identifier objectId, int updateId)
		{
			DeleteIndependentEntity1Core(objectId, updateId, this.ignoreCollision);
		}

		public override void DeleteIndependentEntity1(IndependentEntity1Identifier objectId, int updateId, bool ignoreCollision)
		{
			DeleteIndependentEntity1Core(objectId, updateId, ignoreCollision);
		}

		protected override void DeleteIndependentEntity1Core(IndependentEntity1Identifier objectId, int updateId, bool ignoreCollision)
		{
			try
			{
				if (this.independentEntity1DeleteCmd == null) CreateIndependentEntity1DeleteCommand();
				SqlCommand cmd = this.independentEntity1DeleteCmd;

				// Set input parameters specific to the delete operation.

				cmd.Parameters["@p_independent_entity_1_id"].Value = objectId.IndependentEntity1Id;
				if (ignoreCollision)
					cmd.Parameters["@p_ignore_collision_"].Value = 1;
				else
					cmd.Parameters["@p_ignore_collision_"].Value = 0;
				cmd.Parameters["@p_update_id_"].Value = updateId;

				// Call stored procedure.
				BeforeCommandExecute();
				cmd.ExecuteNonQuery();

				// Process results.

				switch ((int)cmd.Parameters["@p_rc_"].Value)
				{
					case 1: // Update successful.
						break;
					case 2: // Collision - object updated by another user.
						throw new SingleCollisionException(RepositoryExceptionMessage.UpdateCollisionDetected, EntityClass.IndependentEntity1, objectId, CollisionType.Update, (string)cmd.Parameters["@p_user_"].Value, (DateTime)cmd.Parameters["@p_update_ts_"].Value);
					case 3: // Collision - object physically deleted by another user.
						throw new SingleCollisionException(RepositoryExceptionMessage.DeleteCollisionDetected, EntityClass.IndependentEntity1, objectId, CollisionType.Delete, null, DateTime.MinValue);
				}
			}
			catch (SqlException e)
			{
				throw new DALException(RepositoryExceptionMessage.UnexpectedExceptionDetected, e);
			}
			finally
			{
				AfterCommandExecute();
			}
		}


		public override void SaveIndependentEntity1(IIndependentEntity1 independentEntity1)
		{
			SaveIndependentEntity1Core(independentEntity1, this.ignoreCollision);
		}

		public override void SaveIndependentEntity1(IIndependentEntity1 independentEntity1, bool ignoreCollision)
		{
			SaveIndependentEntity1Core(independentEntity1, ignoreCollision);
		}

		protected override void SaveIndependentEntity1Core(IIndependentEntity1 independentEntity1, bool ignoreCollision)
		{
			// When transaction support is added, ApplySaveLog must not be called if an exception is encountered.
			SaveLog saveLog = new SaveLog();
			try
			{
				SaveIndependentEntity1Core(independentEntity1, ignoreCollision, saveLog);
				saveLog.ApplySaveLog();
			}
			catch (Exception)
			{
				// Still call ApplySaveLog because no support for transaction/rollback yet.
				saveLog.ApplySaveLog();
				// Reverse the commit state set by ApplySaveLog.
				independentEntity1.HasUncommittedChanges = true; // This line ensures that errors in saving dependent entities don't result in the parent being marked as uncommitted (because it isn't).
				throw;
			}
		}

		// The core function for saving a specific IndependentEntity1 instance as well as related entity objects.
		// If an object is marked for deletion, this function calls DeleteIndependentEntity1Core.
		// This function must NEVER update any properties of the entity object (independentEntity1).
		// Such updates must be cached in saveLog and applied by the caller depending upon whether or not an exception occurred and if the update is part of a transaction.
		protected override void SaveIndependentEntity1Core(IIndependentEntity1 independentEntity1, bool ignoreCollision, SaveLog saveLog)
		{
			if (independentEntity1.MarkedForDeletion)
			{
				// Database level cascade delete will take care of whatever dependent and relation entities are associated with IndependentEntity1.
				DeleteIndependentEntity1Core(independentEntity1, ignoreCollision, saveLog);
			}
			else
			{
				#region Entity Object

				bool insertOperation = SaveIndependentEntity1EntityObjectCore(independentEntity1, ignoreCollision, saveLog);

				#endregion Entity Object

				#region Owned Child Entity Objects

				// Save child DependentEntity1 objects.
				// Relationship has a cardinality of many.
				switch (independentEntity1.ChildOwnedDependentEntity1ListLoadStatus)
				{
					case LoadStatus.Full:
						// The content of the child collection is what the repository should be synchronized with.
						if (independentEntity1.HasChildOwnedDependentEntity1Objects(false))
						{
							if (insertOperation)
							{
								// This is the first time the parent IndependentEntity1 object has been saved.
								// Therefore, it cannot have any child DependentEntity1 objects in the repository.
								// Therefore, it is not necessary to check the repository to determine if existing child objects need to be removed because they are not associated with the in-memory copy of the parent object.
								this.Save((IList)independentEntity1.ChildOwnedDependentEntity1List, false);
							}
							else
							{
								// Since the parent IndependentEntity1 object existed in the repository prior to this call to save, it is possible that there already exist child DependentEntity1 objects in the repository.
								// The repository set of child DependentEntity1 objects has to be synchronized with the in-memory set.

								// Get a list of object ids of DependentEntity1 objects associated with the database copy of IndependentEntity1.
								ArrayList dependentEntity1Ids = GetAssociatedDependentEntity1Ids(-1, DependentEntity1PropertyName.ParentOwnerIndependentEntity1EntityObjectId, independentEntity1.ObjectId);

								// Remove from the list ids of DependentEntity1 objects that are related to the in-memory copy of IndependentEntity1.
								// After this is done, the list will contain ids of those DependentEntity1 objects that must be deleted from the repository since they are no longer related to the in-memory copy of IndependentEntity1.
								dependentEntity1Ids.Sort();
								int index;
								foreach (IDependentEntity1 childDependentEntity1 in independentEntity1.ChildOwnedDependentEntity1List)
								{
									index = dependentEntity1Ids.BinarySearch(childDependentEntity1.ObjectId);
									if (index >= 0) dependentEntity1Ids.RemoveAt(index);
								}

								// The remaining ids in dependentEntity1Ids collection identify the DependentEntity1 objects to be deleted from the database, since they are no longer related to the in-memory copy of IndependentEntity1.
								for (index = 0; index < dependentEntity1Ids.Count; ++index)
									// The following delete call sets ignoreCollision = true.
									// This is because update ids were not loaded along with the object ids.
									// Without update ids, collision detection isn't possible.
									// There is no need for collision detection at this point anyway, because the parent IndependentEntity1 object
									// has passed its collision test.
									DeleteDependentEntity1Core((DependentEntity1Identifier)dependentEntity1Ids[index], 0, true); // If ignoreCollision = true, updateId is ignored.

								// Save the child entity objects.
								this.Save((IList)independentEntity1.ChildOwnedDependentEntity1List, true);
							} // if (insertOperation)
						}
						else
						{
							// The LoadStatus is Full and the child collecton is empty.
							// If the parent IndependentEntity1 object existed in the repository prior to this save, there is a chance the repository copy has child DependentEntity1 objects that must be deleted.
							if (!insertOperation)
							{
								// Delete any child DependentEntity1 object that may exist in the repository.
								// The most efficient way to synchronize the database is to simply issue a bulk erase call to remove all associated DependentEntity1 objects from the database.
								this.DeleteDependentEntity1(new SearchCondition().AppendSearchCondition(DependentEntity1PropertyName.ParentOwnerIndependentEntity1EntityObjectId, SearchConditionExpressionOperator.Equal, independentEntity1.ObjectId));
							}
						} // if (independentEntity1.HasChildOwnedDependentEntity1Objects(false))
						break;
					case LoadStatus.Partial:
						// Update the set of child DependentEntity1 objects in the repository to be the union of the existing child objects in the repository and the in-memory child objects.
						if (independentEntity1.HasChildOwnedDependentEntity1Objects(false))
							this.Save((IList)independentEntity1.ChildOwnedDependentEntity1List, true);
						break;
					case LoadStatus.NotLoaded:
						// In-memory copy of IndependentEntity1 has the same child DependentEntity1 objects as the respository counterpart does.
						// Therefore, no repository update is required.
						break;
				}


				#endregion Owned Child Entity Objects

			} // if (independentEntity1.MarkedForDeletion)
		}

		// The core function for saving a specific IndependentEntity1 object.
		// It does not handle deletes (if the entity is marked for deletion) nor updating of related entity objects.
		// This function must NEVER update any properties of the entity object (independentEntity1).
		// Such updates must be cached in saveLog and applied by the caller depending upon whether or not an exception occurred and if the update is part of a transaction.
		protected override bool SaveIndependentEntity1EntityObjectCore(IIndependentEntity1 independentEntity1, bool ignoreCollision, SaveLog saveLog)
		{
			bool insertOperation;

			SaveLogEntry saveLogEntry = new SaveLogEntry();
			// These saveLogEntry assignments must occur here so that they are set if an exception occurs.
			saveLogEntry.EntityObject = independentEntity1;
			saveLogEntry.PreSaveObjectStatus = independentEntity1.ObjectStatus;

			try
			{
				insertOperation = !independentEntity1.ObjectId.HasValue;
				SqlCommand cmd;

				if (insertOperation)
				{
					// Have a new IndependentEntity1 object to save.

					saveLogEntry.RepositoryUpdateOperation = RepositoryUpdateOperation.Insert;

					if (this.independentEntity1InsertCmd == null) CreateIndependentEntity1InsertCommand();
					cmd = this.independentEntity1InsertCmd;
				}
				else
				{
					// Have a previously saved IndependentEntity1 object to save.

					saveLogEntry.RepositoryUpdateOperation = RepositoryUpdateOperation.Update;

					if (this.independentEntity1UpdateCmd == null) CreateIndependentEntity1UpdateCommand();
					cmd = this.independentEntity1UpdateCmd;

					// Set input parameters specific to the update operation.

					cmd.Parameters["@p_independent_entity_1_id"].Value = independentEntity1.IndependentEntity1Id.Value;
					if (ignoreCollision)
						cmd.Parameters["@p_ignore_collision_"].Value = 1;
					else
						cmd.Parameters["@p_ignore_collision_"].Value = 0;
					cmd.Parameters["@p_update_id_"].Value = independentEntity1.UpdateId;
				}

				// Set input parameters common to both insert and update operations.

				// [attr_bool_1]
				cmd.Parameters["@p_attr_bool_1"].Value = independentEntity1.AttrBool1_DBObjectValue;
				// [attr_datetime_1]
				cmd.Parameters["@p_attr_datetime_1"].Value = independentEntity1.AttrDatetime1_DBObjectValue;
				// [attr_integer_1]
				cmd.Parameters["@p_attr_integer_1"].Value = independentEntity1.AttrInteger1_DBObjectValue;
				// [attr_string_1]
				cmd.Parameters["@p_attr_string_1"].Value = independentEntity1.AttrString1_DBObjectValue;
				// [attr_string_2]
				cmd.Parameters["@p_attr_string_2"].Value = independentEntity1.AttrString2_DBObjectValue;
				// [name]
				cmd.Parameters["@p_name"].Value = independentEntity1.Name_DBObjectValue;
				// [status]
				cmd.Parameters["@p_status"].Value = independentEntity1.Status_DBObjectValue;
				cmd.Parameters["@p_user_"].Value = this.user;

				// Call stored procedure.
				BeforeCommandExecute();
				cmd.ExecuteNonQuery();

				// Process results.
				if (insertOperation)
				{
					saveLogEntry.PostSaveObjectStatus = ObjectStatus.Existing;
					((IEditableObject)independentEntity1).BeginEdit();
					IndependentEntity1Identifier identifier = new IndependentEntity1Identifier();
					identifier.IndependentEntity1Id = (int)cmd.Parameters["@p_independent_entity_1_id"].Value;
					independentEntity1.ObjectId = identifier;
					independentEntity1.CreateTimestamp = (DateTime)cmd.Parameters["@p_update_ts_"].Value;
					independentEntity1.CreateUser = this.user;
				}
				else
				{
					int returnCode = (int)cmd.Parameters["@p_rc_"].Value;
					switch (returnCode)
					{
						case 1: // Update successful.
							saveLogEntry.PostSaveObjectStatus = ObjectStatus.Existing;
							((IEditableObject)independentEntity1).BeginEdit();
							independentEntity1.ObjectId = independentEntity1.ObjectId;
							independentEntity1.CreateTimestamp = independentEntity1.CreateTimestamp;
							independentEntity1.CreateUser = independentEntity1.CreateUser;
							break;
						case 2: // Collision - object updated by another user.
							throw new SingleCollisionException(RepositoryExceptionMessage.UpdateCollisionDetected, independentEntity1.EntityClass, independentEntity1.ObjectId, CollisionType.Update, (string)cmd.Parameters["@p_user_"].Value, (DateTime)cmd.Parameters["@p_update_ts_"].Value);
						case 3: // Collision - object physically deleted by another user.
							throw new SingleCollisionException(RepositoryExceptionMessage.DeleteCollisionDetected, independentEntity1.EntityClass, independentEntity1.ObjectId, CollisionType.Delete, null, DateTime.MinValue);
					}
				}
				independentEntity1.LastUpdateTimestamp = (DateTime)cmd.Parameters["@p_update_ts_"].Value;
				independentEntity1.LastUpdateUser = this.user;
				if (cmd.Parameters["@p_update_id_"].Value == DBNull.Value)
					independentEntity1.UpdateId = 0;
				else
					independentEntity1.UpdateId = (int)cmd.Parameters["@p_update_id_"].Value;
				saveLog.Add(saveLogEntry); // SaveLog takes care of calling EndEdit.
			}
			catch (SingleCollisionException e)
			{
				if (e.Collision.CollisionType == CollisionType.Delete)
					saveLogEntry.PostSaveObjectStatus = ObjectStatus.Deleted;
				else if (e.Collision.CollisionType == CollisionType.Update)
					saveLogEntry.PostSaveObjectStatus = ObjectStatus.Outdated;
				saveLog.Add(saveLogEntry);
				if (e.Collision.CollisionType == CollisionType.Delete)
					saveLog.UpdateSaveLogForCascadeDelete((IEntityObject)independentEntity1);
				throw;
			}
			catch (SqlException e)
			{
				throw new DALException(RepositoryExceptionMessage.UnexpectedExceptionDetected, e);
			}
			finally
			{
				AfterCommandExecute();
			}

			return insertOperation;
		}

		protected virtual IIndependentEntity1 OnIndependentEntity1Load(IIndependentEntity1 independentEntity1)
		{
			return independentEntity1;
		}

		#endregion IndependentEntity1 related members.

		#region IndependentEntity2 related members.

		public override IIndependentEntity2List FindIndependentEntity2(int maxCount, SearchCondition searchCondition)
		{
			return this.FindIndependentEntity2(maxCount, searchCondition, null, null);
		}

		public override IIndependentEntity2List FindIndependentEntity2(int maxCount, SearchCondition searchCondition, SortSpecification sortSpecification)
		{
			return this.FindIndependentEntity2(maxCount, searchCondition, sortSpecification, null);
		}

		public override IIndependentEntity2List FindIndependentEntity2(int maxCount, SearchCondition searchCondition, IEntityObjectContext context)
		{
			return this.FindIndependentEntity2(maxCount, searchCondition, null, context);
		}

		public override IIndependentEntity2List FindIndependentEntity2(int maxCount, SearchCondition searchCondition, SortSpecification sortSpecification, IEntityObjectContext context)
		{
			try
			{
				string sql = "SELECT ";
				if (maxCount > -1) sql += "TOP " + maxCount.ToString("d") + " ";
				sql +=
				"[independent_entity_2_id]," +
				"[attr_bool_1]," +
				"[attr_datetime_1]," +
				"[attr_integer_1]," +
				"[attr_string_1]," +
				"[attr_string_2]," +
				"[name]," +
				"[status]," +
				"[create_datetime]," +
				"[create_user]," +
				"[update_datetime]," +
				"[update_id]," +
				"[update_user]" +
				" FROM [independent_entity_2]";
				SqlCommand cmd = new SqlCommand();
				cmd.CommandTimeout = this.commandTimeout;
				cmd.Connection = this.connection;
				//
				// Add SQL Where criteria if required.
				//
				string whereClause;
				ArrayList whereClauseParameters;
				BuildWhereClause(searchCondition, out whereClause, out whereClauseParameters);
				if (whereClause != null && whereClause != "")
				{
					sql = sql + " WHERE " + whereClause;
					foreach (SqlParameter param in whereClauseParameters)
					{
						cmd.Parameters.Add(param);
					}
				}
				//
				// Add SQL ORDER BY clause if required.
				//
				string orderByClause;
				if (sortSpecification == null)
					orderByClause = BuildOrderByClause(this.independentEntity2SortSpecification);
				else
					orderByClause = BuildOrderByClause(sortSpecification);
				if (orderByClause != null && orderByClause != "")
					sql += " ORDER BY " + orderByClause;
				//
				// Execute SQL Select command and convert results into a list of IndependentEntity2 objects.
				//
				cmd.CommandText = sql;
				cmd.CommandType = CommandType.Text;
				BeforeCommandExecute();
				SqlDataReader sdr = cmd.ExecuteReader();
				IIndependentEntity2List independentEntity2List = (IIndependentEntity2List)this.classFactory.GetEntityListObject(EntityClass.IndependentEntity2);
				if (sdr.HasRows)
				{
					if (context == null)
					{
						while (sdr.Read())
						{
							independentEntity2List.Add(CreateIndependentEntity2FromSqlDataReader(sdr));
						}
					}
					else
					{
						IndependentEntity2Identifier? identifier;
						IEntityObjectContextItem obj;
						while (sdr.Read())
						{
							// Get the primary object id.
							identifier = CreateIndependentEntity2IdentifierFromSqlDataReader(sdr, 0);
							if (identifier == null)
							{
								independentEntity2List.Add(CreateIndependentEntity2FromSqlDataReader(sdr));
							}
							else
							{
								if ((obj = context.Get((IIdentifier)identifier.Value)) == null)
									independentEntity2List.Add(CreateIndependentEntity2FromSqlDataReader(sdr));
								else
									independentEntity2List.Add(obj);
							}
						}
					}
				}
				sdr.Close();

				return independentEntity2List;
			}
			catch (SqlException e)
			{
				throw new DALException(RepositoryExceptionMessage.UnexpectedExceptionDetected, e);
			}
			finally
			{
				AfterCommandExecute();
			}
		}

		// Parameter propertyName must be a IndependentEntity2PropertyName class constant (IndependentEntity2BasePropertyName is a subset of IndependentEntity2PropertyName).
		public override ArrayList GetAssociatedIndependentEntity2Ids(int maxCount, IndependentEntity2PropertyName propertyName, object value)
		{
			try
			{
				// Create SQL command.

				string sql = "SELECT ";
				if (maxCount > -1) sql += "TOP " + maxCount.ToString("d") + " ";
				sql +=
				"[independent_entity_2_id] " +
				"FROM [independent_entity_2]";

				// Add Where condition.

				SearchCondition searchCondition = new SearchCondition().AppendSearchCondition(propertyName, SearchConditionExpressionOperator.Equal, value);
				string whereClause;
				ArrayList whereClauseParameters;
				BuildWhereClause(searchCondition, out whereClause, out whereClauseParameters);
				sql = sql + " WHERE " + whereClause;
				SqlCommand cmd = new SqlCommand(sql, this.connection);
				cmd.CommandTimeout = this.commandTimeout;
				cmd.CommandType = CommandType.Text;
				foreach (SqlParameter param in whereClauseParameters)
					cmd.Parameters.Add(param);

				// Execute query.

				BeforeCommandExecute();
				SqlDataReader sdr = cmd.ExecuteReader();
				ArrayList independentEntity2IdentifierList = new ArrayList();
				if (sdr.HasRows)
				{
					while (sdr.Read())
						independentEntity2IdentifierList.Add(CreateIndependentEntity2IdentifierFromSqlDataReader(sdr, 0));
				}
				sdr.Close();

				return independentEntity2IdentifierList;
			}
			catch (SqlException e)
			{
				throw new DALException(RepositoryExceptionMessage.UnexpectedExceptionDetected, e);
			}
			finally
			{
				AfterCommandExecute();
			}
		}

		public SortSpecification IndependentEntity2SortSpecification
		{
			get
			{
				return this.independentEntity2SortSpecification;
			}
			set
			{
				this.independentEntity2SortSpecification = value;
			}
		}

		public virtual SortSpecification IndependentEntity2DefaultSortSpecification
		{
			get
			{
				return null;
			}
		}

		public override SortSpecification IndependentEntity2_ChildOwnedRelationshipEntity1SortSpecification
		{
			get
			{
				return this.independentEntity2_ChildOwnedRelationshipEntity1SortSpecification;
			}
			set
			{
				this.independentEntity2_ChildOwnedRelationshipEntity1SortSpecification = value;
			}
		}

		public virtual SortSpecification IndependentEntity2_ChildOwnedRelationshipEntity1DefaultSortSpecification
		{
			get
			{
				return null;
			}
		}

		protected override void DeleteIndependentEntity2(SearchCondition searchCondition)
		{
			// To avoid accidental deletion of all IndependentEntity2 objects, insist on a search condition.
			bool haveSearchCondition;
			if (searchCondition == null)
				haveSearchCondition = false;
			else
				haveSearchCondition = (!searchCondition.IsNullCondition());
			if (!haveSearchCondition) throw new DALException(RepositoryExceptionMessage.NonEmptySearchConditionRequired);

			try
			{
				SqlCommand cmd = new SqlCommand();
				cmd.CommandTimeout = this.commandTimeout;
				cmd.Connection = this.connection;
				string sql = "DELETE FROM [independent_entity_2]";
				//
				// Add SQL Where criteria if required.
				//
				string sqlWhereConditionText;
				ArrayList sqlWhereConditionParameters;
				BuildWhereClause(searchCondition, out sqlWhereConditionText, out sqlWhereConditionParameters);
				if (sqlWhereConditionText != null && sqlWhereConditionText != "")
				{
					sql = sql + " WHERE " + sqlWhereConditionText;
					foreach (SqlParameter param in sqlWhereConditionParameters)
					{
						cmd.Parameters.Add(param);
					}
				}
				cmd.CommandText = sql;
				cmd.CommandType = CommandType.Text;
				//
				// Execute SQL Delete command.
				//
				BeforeCommandExecute();
				cmd.ExecuteNonQuery();
			}
			catch (SqlException e)
			{
				throw new DALException(RepositoryExceptionMessage.UnexpectedExceptionDetected, e);
			}
			finally
			{
				AfterCommandExecute();
			}
		}


		public override IIndependentEntity2 GetIndependentEntity2(IndependentEntity2Identifier objectId)
		{
			return this.GetIndependentEntity2(objectId, null);
		}

		public override IIndependentEntity2 GetIndependentEntity2(IndependentEntity2Identifier objectId, IEntityObjectContext context)
		{
			try
			{
				IIndependentEntity2 independentEntity2 = null;

				if (context == null || (context != null && (independentEntity2 = (IIndependentEntity2)context.Get((IIdentifier)objectId)) == null))
				{
					if (this.independentEntity2GetCmd == null) CreateIndependentEntity2GetCommand();
					SqlCommand cmd = this.independentEntity2GetCmd;

					// Set input parameters.
					cmd.Parameters["@p_independent_entity_2_id"].Value = objectId.IndependentEntity2Id;

					// Call stored procedure.
					BeforeCommandExecute();
					cmd.ExecuteNonQuery();

					// Process results.

					if ((int)cmd.Parameters["@p_rc_"].Value == 1)
					{
						// Object retrieved successfully.

						independentEntity2 = (IIndependentEntity2)this.classFactory.GetEntityObject(EntityClass.IndependentEntity2);
						independentEntity2.ObjectId = objectId;
						// [attr_bool_1]
						if (cmd.Parameters["@p_attr_bool_1"].Value == DBNull.Value)
						{
							independentEntity2.AttrBool1 = null;
						}
						else
						{
							independentEntity2.AttrBool1 = (bool)cmd.Parameters["@p_attr_bool_1"].Value;
						}
						// [attr_datetime_1]
						if (cmd.Parameters["@p_attr_datetime_1"].Value == DBNull.Value)
						{
							independentEntity2.AttrDatetime1 = null;
						}
						else
						{
							independentEntity2.AttrDatetime1 = (DateTime)cmd.Parameters["@p_attr_datetime_1"].Value;
						}
						// [attr_integer_1]
						if (cmd.Parameters["@p_attr_integer_1"].Value == DBNull.Value)
						{
							independentEntity2.AttrInteger1 = null;
						}
						else
						{
							independentEntity2.AttrInteger1 = (int)cmd.Parameters["@p_attr_integer_1"].Value;
						}
						// [attr_string_1]
						if (cmd.Parameters["@p_attr_string_1"].Value == DBNull.Value)
						{
							independentEntity2.AttrString1 = null;
						}
						else
						{
							independentEntity2.AttrString1 = (string)cmd.Parameters["@p_attr_string_1"].Value;
						}
						// [attr_string_2]
						if (cmd.Parameters["@p_attr_string_2"].Value == DBNull.Value)
						{
							independentEntity2.AttrString2 = null;
						}
						else
						{
							independentEntity2.AttrString2 = (string)cmd.Parameters["@p_attr_string_2"].Value;
						}
						// [name]
						if (cmd.Parameters["@p_name"].Value == DBNull.Value)
						{
							independentEntity2.Name = null;
						}
						else
						{
							independentEntity2.Name = (string)cmd.Parameters["@p_name"].Value;
						}
						// [status]
						if (cmd.Parameters["@p_status"].Value == DBNull.Value)
						{
							independentEntity2.Status = null;
						}
						else
						{
							independentEntity2.Status = (string)cmd.Parameters["@p_status"].Value;
						}
						// [create_datetime]
						if (cmd.Parameters["@p_create_datetime"].Value == DBNull.Value)
							independentEntity2.CreateTimestamp = null;
						else
							independentEntity2.CreateTimestamp = (DateTime)cmd.Parameters["@p_create_datetime"].Value;
						// [create_user]
						if (cmd.Parameters["@p_create_user"].Value == DBNull.Value)
							independentEntity2.CreateUser = null;
						else
							independentEntity2.CreateUser = (string)cmd.Parameters["@p_create_user"].Value;
						// [update_datetime]
						if (cmd.Parameters["@p_update_datetime"].Value == DBNull.Value)
							independentEntity2.LastUpdateTimestamp = null;
						else
							independentEntity2.LastUpdateTimestamp = (DateTime)cmd.Parameters["@p_update_datetime"].Value;
						// [update_id]
						if (cmd.Parameters["@p_update_id"].Value == DBNull.Value)
							independentEntity2.UpdateId = 0;
						else
							independentEntity2.UpdateId = (int)cmd.Parameters["@p_update_id"].Value;
						// [update_user]
						if (cmd.Parameters["@p_update_user"].Value == DBNull.Value)
							independentEntity2.LastUpdateUser = null;
						else
							independentEntity2.LastUpdateUser = (string)cmd.Parameters["@p_update_user"].Value;
						independentEntity2.ObjectStatus = ObjectStatus.Existing;
						independentEntity2.HasUncommittedChanges = false;
					}

					// Add newly loaded object to context.
					if (context != null)
						context.Add((IEntityObjectContextItem)independentEntity2);
				}

				return this.OnIndependentEntity2Load(independentEntity2);
			}
			catch (SqlException e)
			{
				throw new DALException(RepositoryExceptionMessage.UnexpectedExceptionDetected, e);
			}
			finally
			{
				AfterCommandExecute();
			}
		}

		public override byte[] GetIndependentEntity2BLOB(IndependentEntity2Identifier objectId, int updateId, string columnName)
		{
			return GetIndependentEntity2BLOBCore(objectId, updateId, columnName, this.ignoreCollision);
		}

		public override byte[] GetIndependentEntity2BLOB(IndependentEntity2Identifier objectId, int updateId, string columnName, bool ignoreCollision)
		{
			return GetIndependentEntity2BLOBCore(objectId, updateId, columnName, ignoreCollision);
		}

		protected override byte[] GetIndependentEntity2BLOBCore(IndependentEntity2Identifier objectId, int updateId, string columnName, bool ignoreCollision)
		{
			try
			{
				if (this.independentEntity2GetBLOBCmd == null)
					CreateIndependentEntity2GetBLOBCommand();
				SqlCommand cmd = this.independentEntity2GetBLOBCmd;

				// Set input parameters.

				cmd.Parameters["@p_independent_entity_2_id"].Value = objectId.IndependentEntity2Id;
				if (ignoreCollision)
					cmd.Parameters["@p_ignore_collision_"].Value = 1;
				else
					cmd.Parameters["@p_ignore_collision_"].Value = 0;
				cmd.Parameters["@p_update_id_"].Value = updateId;
				cmd.Parameters["@p_column_name_"].Value = columnName;

				// Call stored procedure.
				BeforeCommandExecute();
				cmd.ExecuteNonQuery();

				// Process results.

				switch ((int)cmd.Parameters["@p_rc_"].Value)
				{
					case 1: // Fetch successful.
						if (cmd.Parameters["@p_blob_"].Value == DBNull.Value)
							return null;
						else
							return (byte[])cmd.Parameters["@p_blob_"].Value;
					case 2: // Collision - object updated by another user.
						throw new SingleCollisionException(RepositoryExceptionMessage.UpdateCollisionDetected, EntityClass.IndependentEntity2, objectId, CollisionType.Update, (string)cmd.Parameters["@p_user_"].Value, (DateTime)cmd.Parameters["@p_update_ts_"].Value);
					case 3: // Collision - object physically deleted by another user.
						throw new SingleCollisionException(RepositoryExceptionMessage.DeleteCollisionDetected, EntityClass.IndependentEntity2, objectId, CollisionType.Delete, null, DateTime.MinValue);
					default:
						return null;
				}
			}
			catch (SqlException e)
			{
				throw new DALException(RepositoryExceptionMessage.UnexpectedExceptionDetected, e);
			}
			finally
			{
				AfterCommandExecute();
			}
		}


		public override void DeleteIndependentEntity2(IIndependentEntity2 independentEntity2)
		{
			DeleteIndependentEntity2Core(independentEntity2, this.ignoreCollision);
		}

		public override void DeleteIndependentEntity2(IIndependentEntity2 independentEntity2, bool ignoreCollision)
		{
			DeleteIndependentEntity2Core(independentEntity2, ignoreCollision);
		}

		protected override void DeleteIndependentEntity2Core(IIndependentEntity2 independentEntity2, bool ignoreCollision)
		{
			// When transaction support is added, ApplySaveLog must not be called if an exception is encountered.
			SaveLog saveLog = new SaveLog();
			try
			{
				DeleteIndependentEntity2Core(independentEntity2, ignoreCollision, saveLog);
				saveLog.ApplySaveLog();
			}
			catch (Exception)
			{
				// Still call ApplySaveLog because no support for transaction/rollback yet.
				saveLog.ApplySaveLog();
				throw;
			}
		}

		// Because cascade delete operations are handled at the DB level, this implementation of this function is trivial.
		protected override void DeleteIndependentEntity2Core(IIndependentEntity2 independentEntity2, bool ignoreCollision, SaveLog saveLog)
		{
			DeleteIndependentEntity2EntityObjectCore(independentEntity2, ignoreCollision, saveLog);
		}

		protected override void DeleteIndependentEntity2EntityObjectCore(IIndependentEntity2 independentEntity2, bool ignoreCollision, SaveLog saveLog)
		{
			SaveLogEntry saveLogEntry = new SaveLogEntry();
			// These saveLogEntry assignments must occur here so that they are set if an exception occurs.
			saveLogEntry.EntityObject = independentEntity2;
			saveLogEntry.PreSaveObjectStatus = independentEntity2.ObjectStatus;
			try
			{
				saveLogEntry.RepositoryUpdateOperation = RepositoryUpdateOperation.Delete;

				DeleteIndependentEntity2((IndependentEntity2Identifier)independentEntity2.ObjectId, independentEntity2.UpdateId, ignoreCollision);

				saveLogEntry.PostSaveObjectStatus = ObjectStatus.Deleted;
				saveLog.Add(saveLogEntry);
				// Add SaveLog entries for in-memory objects owned by independentEntity2 that must have been cascade deleted by the repository.
				saveLog.UpdateSaveLogForCascadeDelete((IEntityObject)independentEntity2);
			}
			catch (SingleCollisionException e)
			{
				// Update the object's status to reflect the collision.
				if (e.Collision.CollisionType == CollisionType.Delete)
					// Collision - object physically deleted by another user.
					saveLogEntry.PostSaveObjectStatus = ObjectStatus.Deleted;
				else if (e.Collision.CollisionType == CollisionType.Update)
					// Collision - object updated by another user.
					saveLogEntry.PostSaveObjectStatus = ObjectStatus.Outdated;
				saveLog.Add(saveLogEntry);
				if (e.Collision.CollisionType == CollisionType.Delete)
				{
					saveLog.UpdateSaveLogForCascadeDelete((IEntityObject)independentEntity2);
				}
				// Rethrow the collision exception.
				throw;
			}
		}

		public override void DeleteIndependentEntity2(IndependentEntity2Identifier objectId, int updateId)
		{
			DeleteIndependentEntity2Core(objectId, updateId, this.ignoreCollision);
		}

		public override void DeleteIndependentEntity2(IndependentEntity2Identifier objectId, int updateId, bool ignoreCollision)
		{
			DeleteIndependentEntity2Core(objectId, updateId, ignoreCollision);
		}

		protected override void DeleteIndependentEntity2Core(IndependentEntity2Identifier objectId, int updateId, bool ignoreCollision)
		{
			try
			{
				if (this.independentEntity2DeleteCmd == null) CreateIndependentEntity2DeleteCommand();
				SqlCommand cmd = this.independentEntity2DeleteCmd;

				// Set input parameters specific to the delete operation.

				cmd.Parameters["@p_independent_entity_2_id"].Value = objectId.IndependentEntity2Id;
				if (ignoreCollision)
					cmd.Parameters["@p_ignore_collision_"].Value = 1;
				else
					cmd.Parameters["@p_ignore_collision_"].Value = 0;
				cmd.Parameters["@p_update_id_"].Value = updateId;

				// Call stored procedure.
				BeforeCommandExecute();
				cmd.ExecuteNonQuery();

				// Process results.

				switch ((int)cmd.Parameters["@p_rc_"].Value)
				{
					case 1: // Update successful.
						break;
					case 2: // Collision - object updated by another user.
						throw new SingleCollisionException(RepositoryExceptionMessage.UpdateCollisionDetected, EntityClass.IndependentEntity2, objectId, CollisionType.Update, (string)cmd.Parameters["@p_user_"].Value, (DateTime)cmd.Parameters["@p_update_ts_"].Value);
					case 3: // Collision - object physically deleted by another user.
						throw new SingleCollisionException(RepositoryExceptionMessage.DeleteCollisionDetected, EntityClass.IndependentEntity2, objectId, CollisionType.Delete, null, DateTime.MinValue);
				}
			}
			catch (SqlException e)
			{
				throw new DALException(RepositoryExceptionMessage.UnexpectedExceptionDetected, e);
			}
			finally
			{
				AfterCommandExecute();
			}
		}


		public override void SaveIndependentEntity2(IIndependentEntity2 independentEntity2)
		{
			SaveIndependentEntity2Core(independentEntity2, this.ignoreCollision);
		}

		public override void SaveIndependentEntity2(IIndependentEntity2 independentEntity2, bool ignoreCollision)
		{
			SaveIndependentEntity2Core(independentEntity2, ignoreCollision);
		}

		protected override void SaveIndependentEntity2Core(IIndependentEntity2 independentEntity2, bool ignoreCollision)
		{
			// When transaction support is added, ApplySaveLog must not be called if an exception is encountered.
			SaveLog saveLog = new SaveLog();
			try
			{
				SaveIndependentEntity2Core(independentEntity2, ignoreCollision, saveLog);
				saveLog.ApplySaveLog();
			}
			catch (Exception)
			{
				// Still call ApplySaveLog because no support for transaction/rollback yet.
				saveLog.ApplySaveLog();
				// Reverse the commit state set by ApplySaveLog.
				independentEntity2.HasUncommittedChanges = true; // This line ensures that errors in saving dependent entities don't result in the parent being marked as uncommitted (because it isn't).
				throw;
			}
		}

		// The core function for saving a specific IndependentEntity2 instance as well as related entity objects.
		// If an object is marked for deletion, this function calls DeleteIndependentEntity2Core.
		// This function must NEVER update any properties of the entity object (independentEntity2).
		// Such updates must be cached in saveLog and applied by the caller depending upon whether or not an exception occurred and if the update is part of a transaction.
		protected override void SaveIndependentEntity2Core(IIndependentEntity2 independentEntity2, bool ignoreCollision, SaveLog saveLog)
		{
			if (independentEntity2.MarkedForDeletion)
			{
				// Database level cascade delete will take care of whatever dependent and relation entities are associated with IndependentEntity2.
				DeleteIndependentEntity2Core(independentEntity2, ignoreCollision, saveLog);
			}
			else
			{
				#region Entity Object

				bool insertOperation = SaveIndependentEntity2EntityObjectCore(independentEntity2, ignoreCollision, saveLog);

				#endregion Entity Object

				#region Owned Child Entity Objects

				// Save child RelationshipEntity1 objects.
				// Relationship has a cardinality of many.
				switch (independentEntity2.ChildOwnedRelationshipEntity1ListLoadStatus)
				{
					case LoadStatus.Full:
						// The content of the child collection is what the repository should be synchronized with.
						if (independentEntity2.HasChildOwnedRelationshipEntity1Objects(false))
						{
							if (insertOperation)
							{
								// This is the first time the parent IndependentEntity2 object has been saved.
								// Therefore, it cannot have any child RelationshipEntity1 objects in the repository.
								// Therefore, it is not necessary to check the repository to determine if existing child objects need to be removed because they are not associated with the in-memory copy of the parent object.
								this.Save((IList)independentEntity2.ChildOwnedRelationshipEntity1List, false);
							}
							else
							{
								// Since the parent IndependentEntity2 object existed in the repository prior to this call to save, it is possible that there already exist child RelationshipEntity1 objects in the repository.
								// The repository set of child RelationshipEntity1 objects has to be synchronized with the in-memory set.

								// Get a list of object ids of RelationshipEntity1 objects associated with the database copy of IndependentEntity2.
								ArrayList relationshipEntity1Ids = GetAssociatedRelationshipEntity1Ids(-1, RelationshipEntity1PropertyName.ParentOwnerIndependentEntity2EntityObjectId, independentEntity2.ObjectId);

								// Remove from the list ids of RelationshipEntity1 objects that are related to the in-memory copy of IndependentEntity2.
								// After this is done, the list will contain ids of those RelationshipEntity1 objects that must be deleted from the repository since they are no longer related to the in-memory copy of IndependentEntity2.
								relationshipEntity1Ids.Sort();
								int index;
								foreach (IRelationshipEntity1 childRelationshipEntity1 in independentEntity2.ChildOwnedRelationshipEntity1List)
								{
									index = relationshipEntity1Ids.BinarySearch(childRelationshipEntity1.ObjectId);
									if (index >= 0) relationshipEntity1Ids.RemoveAt(index);
								}

								// The remaining ids in relationshipEntity1Ids collection identify the RelationshipEntity1 objects to be deleted from the database, since they are no longer related to the in-memory copy of IndependentEntity2.
								for (index = 0; index < relationshipEntity1Ids.Count; ++index)
									// The following delete call sets ignoreCollision = true.
									// This is because update ids were not loaded along with the object ids.
									// Without update ids, collision detection isn't possible.
									// There is no need for collision detection at this point anyway, because the parent IndependentEntity2 object
									// has passed its collision test.
									DeleteRelationshipEntity1Core((RelationshipEntity1Identifier)relationshipEntity1Ids[index], 0, true); // If ignoreCollision = true, updateId is ignored.

								// Save the child entity objects.
								this.Save((IList)independentEntity2.ChildOwnedRelationshipEntity1List, true);
							} // if (insertOperation)
						}
						else
						{
							// The LoadStatus is Full and the child collecton is empty.
							// If the parent IndependentEntity2 object existed in the repository prior to this save, there is a chance the repository copy has child RelationshipEntity1 objects that must be deleted.
							if (!insertOperation)
							{
								// Delete any child RelationshipEntity1 object that may exist in the repository.
								// The most efficient way to synchronize the database is to simply issue a bulk erase call to remove all associated RelationshipEntity1 objects from the database.
								this.DeleteRelationshipEntity1(new SearchCondition().AppendSearchCondition(RelationshipEntity1PropertyName.ParentOwnerIndependentEntity2EntityObjectId, SearchConditionExpressionOperator.Equal, independentEntity2.ObjectId));
							}
						} // if (independentEntity2.HasChildOwnedRelationshipEntity1Objects(false))
						break;
					case LoadStatus.Partial:
						// Update the set of child RelationshipEntity1 objects in the repository to be the union of the existing child objects in the repository and the in-memory child objects.
						if (independentEntity2.HasChildOwnedRelationshipEntity1Objects(false))
							this.Save((IList)independentEntity2.ChildOwnedRelationshipEntity1List, true);
						break;
					case LoadStatus.NotLoaded:
						// In-memory copy of IndependentEntity2 has the same child RelationshipEntity1 objects as the respository counterpart does.
						// Therefore, no repository update is required.
						break;
				}


				#endregion Owned Child Entity Objects

			} // if (independentEntity2.MarkedForDeletion)
		}

		// The core function for saving a specific IndependentEntity2 object.
		// It does not handle deletes (if the entity is marked for deletion) nor updating of related entity objects.
		// This function must NEVER update any properties of the entity object (independentEntity2).
		// Such updates must be cached in saveLog and applied by the caller depending upon whether or not an exception occurred and if the update is part of a transaction.
		protected override bool SaveIndependentEntity2EntityObjectCore(IIndependentEntity2 independentEntity2, bool ignoreCollision, SaveLog saveLog)
		{
			bool insertOperation;

			SaveLogEntry saveLogEntry = new SaveLogEntry();
			// These saveLogEntry assignments must occur here so that they are set if an exception occurs.
			saveLogEntry.EntityObject = independentEntity2;
			saveLogEntry.PreSaveObjectStatus = independentEntity2.ObjectStatus;

			try
			{
				insertOperation = !independentEntity2.ObjectId.HasValue;
				SqlCommand cmd;

				if (insertOperation)
				{
					// Have a new IndependentEntity2 object to save.

					saveLogEntry.RepositoryUpdateOperation = RepositoryUpdateOperation.Insert;

					if (this.independentEntity2InsertCmd == null) CreateIndependentEntity2InsertCommand();
					cmd = this.independentEntity2InsertCmd;
				}
				else
				{
					// Have a previously saved IndependentEntity2 object to save.

					saveLogEntry.RepositoryUpdateOperation = RepositoryUpdateOperation.Update;

					if (this.independentEntity2UpdateCmd == null) CreateIndependentEntity2UpdateCommand();
					cmd = this.independentEntity2UpdateCmd;

					// Set input parameters specific to the update operation.

					cmd.Parameters["@p_independent_entity_2_id"].Value = independentEntity2.IndependentEntity2Id.Value;
					if (ignoreCollision)
						cmd.Parameters["@p_ignore_collision_"].Value = 1;
					else
						cmd.Parameters["@p_ignore_collision_"].Value = 0;
					cmd.Parameters["@p_update_id_"].Value = independentEntity2.UpdateId;
				}

				// Set input parameters common to both insert and update operations.

				// [attr_bool_1]
				cmd.Parameters["@p_attr_bool_1"].Value = independentEntity2.AttrBool1_DBObjectValue;
				// [attr_datetime_1]
				cmd.Parameters["@p_attr_datetime_1"].Value = independentEntity2.AttrDatetime1_DBObjectValue;
				// [attr_integer_1]
				cmd.Parameters["@p_attr_integer_1"].Value = independentEntity2.AttrInteger1_DBObjectValue;
				// [attr_string_1]
				cmd.Parameters["@p_attr_string_1"].Value = independentEntity2.AttrString1_DBObjectValue;
				// [attr_string_2]
				cmd.Parameters["@p_attr_string_2"].Value = independentEntity2.AttrString2_DBObjectValue;
				// [name]
				cmd.Parameters["@p_name"].Value = independentEntity2.Name_DBObjectValue;
				// [status]
				cmd.Parameters["@p_status"].Value = independentEntity2.Status_DBObjectValue;
				cmd.Parameters["@p_user_"].Value = this.user;

				// Call stored procedure.
				BeforeCommandExecute();
				cmd.ExecuteNonQuery();

				// Process results.
				if (insertOperation)
				{
					saveLogEntry.PostSaveObjectStatus = ObjectStatus.Existing;
					((IEditableObject)independentEntity2).BeginEdit();
					IndependentEntity2Identifier identifier = new IndependentEntity2Identifier();
					identifier.IndependentEntity2Id = (int)cmd.Parameters["@p_independent_entity_2_id"].Value;
					independentEntity2.ObjectId = identifier;
					independentEntity2.CreateTimestamp = (DateTime)cmd.Parameters["@p_update_ts_"].Value;
					independentEntity2.CreateUser = this.user;
				}
				else
				{
					int returnCode = (int)cmd.Parameters["@p_rc_"].Value;
					switch (returnCode)
					{
						case 1: // Update successful.
							saveLogEntry.PostSaveObjectStatus = ObjectStatus.Existing;
							((IEditableObject)independentEntity2).BeginEdit();
							independentEntity2.ObjectId = independentEntity2.ObjectId;
							independentEntity2.CreateTimestamp = independentEntity2.CreateTimestamp;
							independentEntity2.CreateUser = independentEntity2.CreateUser;
							break;
						case 2: // Collision - object updated by another user.
							throw new SingleCollisionException(RepositoryExceptionMessage.UpdateCollisionDetected, independentEntity2.EntityClass, independentEntity2.ObjectId, CollisionType.Update, (string)cmd.Parameters["@p_user_"].Value, (DateTime)cmd.Parameters["@p_update_ts_"].Value);
						case 3: // Collision - object physically deleted by another user.
							throw new SingleCollisionException(RepositoryExceptionMessage.DeleteCollisionDetected, independentEntity2.EntityClass, independentEntity2.ObjectId, CollisionType.Delete, null, DateTime.MinValue);
					}
				}
				independentEntity2.LastUpdateTimestamp = (DateTime)cmd.Parameters["@p_update_ts_"].Value;
				independentEntity2.LastUpdateUser = this.user;
				if (cmd.Parameters["@p_update_id_"].Value == DBNull.Value)
					independentEntity2.UpdateId = 0;
				else
					independentEntity2.UpdateId = (int)cmd.Parameters["@p_update_id_"].Value;
				saveLog.Add(saveLogEntry); // SaveLog takes care of calling EndEdit.
			}
			catch (SingleCollisionException e)
			{
				if (e.Collision.CollisionType == CollisionType.Delete)
					saveLogEntry.PostSaveObjectStatus = ObjectStatus.Deleted;
				else if (e.Collision.CollisionType == CollisionType.Update)
					saveLogEntry.PostSaveObjectStatus = ObjectStatus.Outdated;
				saveLog.Add(saveLogEntry);
				if (e.Collision.CollisionType == CollisionType.Delete)
					saveLog.UpdateSaveLogForCascadeDelete((IEntityObject)independentEntity2);
				throw;
			}
			catch (SqlException e)
			{
				throw new DALException(RepositoryExceptionMessage.UnexpectedExceptionDetected, e);
			}
			finally
			{
				AfterCommandExecute();
			}

			return insertOperation;
		}

		protected virtual IIndependentEntity2 OnIndependentEntity2Load(IIndependentEntity2 independentEntity2)
		{
			return independentEntity2;
		}

		#endregion IndependentEntity2 related members.

		#region RelationshipEntity1 related members.

		public override IRelationshipEntity1List FindRelationshipEntity1(int maxCount, SearchCondition searchCondition)
		{
			return this.FindRelationshipEntity1(maxCount, searchCondition, null, null);
		}

		public override IRelationshipEntity1List FindRelationshipEntity1(int maxCount, SearchCondition searchCondition, SortSpecification sortSpecification)
		{
			return this.FindRelationshipEntity1(maxCount, searchCondition, sortSpecification, null);
		}

		public override IRelationshipEntity1List FindRelationshipEntity1(int maxCount, SearchCondition searchCondition, IEntityObjectContext context)
		{
			return this.FindRelationshipEntity1(maxCount, searchCondition, null, context);
		}

		public override IRelationshipEntity1List FindRelationshipEntity1(int maxCount, SearchCondition searchCondition, SortSpecification sortSpecification, IEntityObjectContext context)
		{
			try
			{
				string sql = "SELECT ";
				if (maxCount > -1) sql += "TOP " + maxCount.ToString("d") + " ";
				sql +=
				"[relationship_entity_1_id]," +
				"[dependent_entity_2_id]," +
				"[independent_entity_2_id]," +
				"[attr_bool_1]," +
				"[attr_datetime_1]," +
				"[attr_integer_1]," +
				"[attr_string_1]," +
				"[attr_string_2]," +
				"[name]," +
				"[status]," +
				"[create_datetime]," +
				"[create_user]," +
				"[update_datetime]," +
				"[update_id]," +
				"[update_user]" +
				" FROM [relationship_entity_1]";
				SqlCommand cmd = new SqlCommand();
				cmd.CommandTimeout = this.commandTimeout;
				cmd.Connection = this.connection;
				//
				// Add SQL Where criteria if required.
				//
				string whereClause;
				ArrayList whereClauseParameters;
				BuildWhereClause(searchCondition, out whereClause, out whereClauseParameters);
				if (whereClause != null && whereClause != "")
				{
					sql = sql + " WHERE " + whereClause;
					foreach (SqlParameter param in whereClauseParameters)
					{
						cmd.Parameters.Add(param);
					}
				}
				//
				// Add SQL ORDER BY clause if required.
				//
				string orderByClause;
				if (sortSpecification == null)
					orderByClause = BuildOrderByClause(this.relationshipEntity1SortSpecification);
				else
					orderByClause = BuildOrderByClause(sortSpecification);
				if (orderByClause != null && orderByClause != "")
					sql += " ORDER BY " + orderByClause;
				//
				// Execute SQL Select command and convert results into a list of RelationshipEntity1 objects.
				//
				cmd.CommandText = sql;
				cmd.CommandType = CommandType.Text;
				BeforeCommandExecute();
				SqlDataReader sdr = cmd.ExecuteReader();
				IRelationshipEntity1List relationshipEntity1List = (IRelationshipEntity1List)this.classFactory.GetEntityListObject(EntityClass.RelationshipEntity1);
				if (sdr.HasRows)
				{
					if (context == null)
					{
						while (sdr.Read())
						{
							relationshipEntity1List.Add(CreateRelationshipEntity1FromSqlDataReader(sdr));
						}
					}
					else
					{
						RelationshipEntity1Identifier? identifier;
						IEntityObjectContextItem obj;
						while (sdr.Read())
						{
							// Get the primary object id.
							identifier = CreateRelationshipEntity1IdentifierFromSqlDataReader(sdr, 0);
							if (identifier == null)
							{
								relationshipEntity1List.Add(CreateRelationshipEntity1FromSqlDataReader(sdr));
							}
							else
							{
								if ((obj = context.Get((IIdentifier)identifier.Value)) == null)
									relationshipEntity1List.Add(CreateRelationshipEntity1FromSqlDataReader(sdr));
								else
									relationshipEntity1List.Add(obj);
							}
						}
					}
				}
				sdr.Close();

				return relationshipEntity1List;
			}
			catch (SqlException e)
			{
				throw new DALException(RepositoryExceptionMessage.UnexpectedExceptionDetected, e);
			}
			finally
			{
				AfterCommandExecute();
			}
		}

		// Parameter propertyName must be a RelationshipEntity1PropertyName class constant (RelationshipEntity1BasePropertyName is a subset of RelationshipEntity1PropertyName).
		public override ArrayList GetAssociatedRelationshipEntity1Ids(int maxCount, RelationshipEntity1PropertyName propertyName, object value)
		{
			try
			{
				// Create SQL command.

				string sql = "SELECT ";
				if (maxCount > -1) sql += "TOP " + maxCount.ToString("d") + " ";
				sql +=
				"[relationship_entity_1_id] " +
				"FROM [relationship_entity_1]";

				// Add Where condition.

				SearchCondition searchCondition = new SearchCondition().AppendSearchCondition(propertyName, SearchConditionExpressionOperator.Equal, value);
				string whereClause;
				ArrayList whereClauseParameters;
				BuildWhereClause(searchCondition, out whereClause, out whereClauseParameters);
				sql = sql + " WHERE " + whereClause;
				SqlCommand cmd = new SqlCommand(sql, this.connection);
				cmd.CommandTimeout = this.commandTimeout;
				cmd.CommandType = CommandType.Text;
				foreach (SqlParameter param in whereClauseParameters)
					cmd.Parameters.Add(param);

				// Execute query.

				BeforeCommandExecute();
				SqlDataReader sdr = cmd.ExecuteReader();
				ArrayList relationshipEntity1IdentifierList = new ArrayList();
				if (sdr.HasRows)
				{
					while (sdr.Read())
						relationshipEntity1IdentifierList.Add(CreateRelationshipEntity1IdentifierFromSqlDataReader(sdr, 0));
				}
				sdr.Close();

				return relationshipEntity1IdentifierList;
			}
			catch (SqlException e)
			{
				throw new DALException(RepositoryExceptionMessage.UnexpectedExceptionDetected, e);
			}
			finally
			{
				AfterCommandExecute();
			}
		}

		public SortSpecification RelationshipEntity1SortSpecification
		{
			get
			{
				return this.relationshipEntity1SortSpecification;
			}
			set
			{
				this.relationshipEntity1SortSpecification = value;
			}
		}

		public virtual SortSpecification RelationshipEntity1DefaultSortSpecification
		{
			get
			{
				return null;
			}
		}

		protected override void DeleteRelationshipEntity1(SearchCondition searchCondition)
		{
			// To avoid accidental deletion of all RelationshipEntity1 objects, insist on a search condition.
			bool haveSearchCondition;
			if (searchCondition == null)
				haveSearchCondition = false;
			else
				haveSearchCondition = (!searchCondition.IsNullCondition());
			if (!haveSearchCondition) throw new DALException(RepositoryExceptionMessage.NonEmptySearchConditionRequired);

			try
			{
				SqlCommand cmd = new SqlCommand();
				cmd.CommandTimeout = this.commandTimeout;
				cmd.Connection = this.connection;
				string sql = "DELETE FROM [relationship_entity_1]";
				//
				// Add SQL Where criteria if required.
				//
				string sqlWhereConditionText;
				ArrayList sqlWhereConditionParameters;
				BuildWhereClause(searchCondition, out sqlWhereConditionText, out sqlWhereConditionParameters);
				if (sqlWhereConditionText != null && sqlWhereConditionText != "")
				{
					sql = sql + " WHERE " + sqlWhereConditionText;
					foreach (SqlParameter param in sqlWhereConditionParameters)
					{
						cmd.Parameters.Add(param);
					}
				}
				cmd.CommandText = sql;
				cmd.CommandType = CommandType.Text;
				//
				// Execute SQL Delete command.
				//
				BeforeCommandExecute();
				cmd.ExecuteNonQuery();
			}
			catch (SqlException e)
			{
				throw new DALException(RepositoryExceptionMessage.UnexpectedExceptionDetected, e);
			}
			finally
			{
				AfterCommandExecute();
			}
		}


		public override IRelationshipEntity1 GetRelationshipEntity1(RelationshipEntity1Identifier objectId)
		{
			return this.GetRelationshipEntity1(objectId, null);
		}

		public override IRelationshipEntity1 GetRelationshipEntity1(RelationshipEntity1Identifier objectId, IEntityObjectContext context)
		{
			try
			{
				IRelationshipEntity1 relationshipEntity1 = null;

				if (context == null || (context != null && (relationshipEntity1 = (IRelationshipEntity1)context.Get((IIdentifier)objectId)) == null))
				{
					if (this.relationshipEntity1GetCmd == null) CreateRelationshipEntity1GetCommand();
					SqlCommand cmd = this.relationshipEntity1GetCmd;

					// Set input parameters.
					cmd.Parameters["@p_relationship_entity_1_id"].Value = objectId.RelationshipEntity1Id;

					// Call stored procedure.
					BeforeCommandExecute();
					cmd.ExecuteNonQuery();

					// Process results.

					if ((int)cmd.Parameters["@p_rc_"].Value == 1)
					{
						// Object retrieved successfully.

						relationshipEntity1 = (IRelationshipEntity1)this.classFactory.GetEntityObject(EntityClass.RelationshipEntity1);
						relationshipEntity1.ObjectId = objectId;
						bool foundNullValue;
						// Process foreign key fields associated with the DependentEntity2 owner relationship.
						foundNullValue = (cmd.Parameters["@p_dependent_entity_2_id"].Value == DBNull.Value);
						if (foundNullValue)
						{
							relationshipEntity1.ParentOwnerDependentEntity2EntityObjectId = null;
						}
						else
						{
							DependentEntity2Identifier identifier0 = new DependentEntity2Identifier();
							identifier0.DependentEntity2Id = (int)cmd.Parameters["@p_dependent_entity_2_id"].Value;
							relationshipEntity1.ParentOwnerDependentEntity2EntityObjectId = identifier0;
						}
						// Process foreign key fields associated with the IndependentEntity2 owner relationship.
						foundNullValue = (cmd.Parameters["@p_independent_entity_2_id"].Value == DBNull.Value);
						if (foundNullValue)
						{
							relationshipEntity1.ParentOwnerIndependentEntity2EntityObjectId = null;
						}
						else
						{
							IndependentEntity2Identifier identifier1 = new IndependentEntity2Identifier();
							identifier1.IndependentEntity2Id = (int)cmd.Parameters["@p_independent_entity_2_id"].Value;
							relationshipEntity1.ParentOwnerIndependentEntity2EntityObjectId = identifier1;
						}
						// [attr_bool_1]
						if (cmd.Parameters["@p_attr_bool_1"].Value == DBNull.Value)
						{
							relationshipEntity1.AttrBool1 = null;
						}
						else
						{
							relationshipEntity1.AttrBool1 = (bool)cmd.Parameters["@p_attr_bool_1"].Value;
						}
						// [attr_datetime_1]
						if (cmd.Parameters["@p_attr_datetime_1"].Value == DBNull.Value)
						{
							relationshipEntity1.AttrDatetime1 = null;
						}
						else
						{
							relationshipEntity1.AttrDatetime1 = (DateTime)cmd.Parameters["@p_attr_datetime_1"].Value;
						}
						// [attr_integer_1]
						if (cmd.Parameters["@p_attr_integer_1"].Value == DBNull.Value)
						{
							relationshipEntity1.AttrInteger1 = null;
						}
						else
						{
							relationshipEntity1.AttrInteger1 = (int)cmd.Parameters["@p_attr_integer_1"].Value;
						}
						// [attr_string_1]
						if (cmd.Parameters["@p_attr_string_1"].Value == DBNull.Value)
						{
							relationshipEntity1.AttrString1 = null;
						}
						else
						{
							relationshipEntity1.AttrString1 = (string)cmd.Parameters["@p_attr_string_1"].Value;
						}
						// [attr_string_2]
						if (cmd.Parameters["@p_attr_string_2"].Value == DBNull.Value)
						{
							relationshipEntity1.AttrString2 = null;
						}
						else
						{
							relationshipEntity1.AttrString2 = (string)cmd.Parameters["@p_attr_string_2"].Value;
						}
						// [name]
						if (cmd.Parameters["@p_name"].Value == DBNull.Value)
						{
							relationshipEntity1.Name = null;
						}
						else
						{
							relationshipEntity1.Name = (string)cmd.Parameters["@p_name"].Value;
						}
						// [status]
						if (cmd.Parameters["@p_status"].Value == DBNull.Value)
						{
							relationshipEntity1.Status = null;
						}
						else
						{
							relationshipEntity1.Status = (string)cmd.Parameters["@p_status"].Value;
						}
						// [create_datetime]
						if (cmd.Parameters["@p_create_datetime"].Value == DBNull.Value)
							relationshipEntity1.CreateTimestamp = null;
						else
							relationshipEntity1.CreateTimestamp = (DateTime)cmd.Parameters["@p_create_datetime"].Value;
						// [create_user]
						if (cmd.Parameters["@p_create_user"].Value == DBNull.Value)
							relationshipEntity1.CreateUser = null;
						else
							relationshipEntity1.CreateUser = (string)cmd.Parameters["@p_create_user"].Value;
						// [update_datetime]
						if (cmd.Parameters["@p_update_datetime"].Value == DBNull.Value)
							relationshipEntity1.LastUpdateTimestamp = null;
						else
							relationshipEntity1.LastUpdateTimestamp = (DateTime)cmd.Parameters["@p_update_datetime"].Value;
						// [update_id]
						if (cmd.Parameters["@p_update_id"].Value == DBNull.Value)
							relationshipEntity1.UpdateId = 0;
						else
							relationshipEntity1.UpdateId = (int)cmd.Parameters["@p_update_id"].Value;
						// [update_user]
						if (cmd.Parameters["@p_update_user"].Value == DBNull.Value)
							relationshipEntity1.LastUpdateUser = null;
						else
							relationshipEntity1.LastUpdateUser = (string)cmd.Parameters["@p_update_user"].Value;
						relationshipEntity1.ObjectStatus = ObjectStatus.Existing;
						relationshipEntity1.HasUncommittedChanges = false;
					}

					// Add newly loaded object to context.
					if (context != null)
						context.Add((IEntityObjectContextItem)relationshipEntity1);
				}

				return this.OnRelationshipEntity1Load(relationshipEntity1);
			}
			catch (SqlException e)
			{
				throw new DALException(RepositoryExceptionMessage.UnexpectedExceptionDetected, e);
			}
			finally
			{
				AfterCommandExecute();
			}
		}

		public override byte[] GetRelationshipEntity1BLOB(RelationshipEntity1Identifier objectId, int updateId, string columnName)
		{
			return GetRelationshipEntity1BLOBCore(objectId, updateId, columnName, this.ignoreCollision);
		}

		public override byte[] GetRelationshipEntity1BLOB(RelationshipEntity1Identifier objectId, int updateId, string columnName, bool ignoreCollision)
		{
			return GetRelationshipEntity1BLOBCore(objectId, updateId, columnName, ignoreCollision);
		}

		protected override byte[] GetRelationshipEntity1BLOBCore(RelationshipEntity1Identifier objectId, int updateId, string columnName, bool ignoreCollision)
		{
			try
			{
				if (this.relationshipEntity1GetBLOBCmd == null)
					CreateRelationshipEntity1GetBLOBCommand();
				SqlCommand cmd = this.relationshipEntity1GetBLOBCmd;

				// Set input parameters.

				cmd.Parameters["@p_relationship_entity_1_id"].Value = objectId.RelationshipEntity1Id;
				if (ignoreCollision)
					cmd.Parameters["@p_ignore_collision_"].Value = 1;
				else
					cmd.Parameters["@p_ignore_collision_"].Value = 0;
				cmd.Parameters["@p_update_id_"].Value = updateId;
				cmd.Parameters["@p_column_name_"].Value = columnName;

				// Call stored procedure.
				BeforeCommandExecute();
				cmd.ExecuteNonQuery();

				// Process results.

				switch ((int)cmd.Parameters["@p_rc_"].Value)
				{
					case 1: // Fetch successful.
						if (cmd.Parameters["@p_blob_"].Value == DBNull.Value)
							return null;
						else
							return (byte[])cmd.Parameters["@p_blob_"].Value;
					case 2: // Collision - object updated by another user.
						throw new SingleCollisionException(RepositoryExceptionMessage.UpdateCollisionDetected, EntityClass.RelationshipEntity1, objectId, CollisionType.Update, (string)cmd.Parameters["@p_user_"].Value, (DateTime)cmd.Parameters["@p_update_ts_"].Value);
					case 3: // Collision - object physically deleted by another user.
						throw new SingleCollisionException(RepositoryExceptionMessage.DeleteCollisionDetected, EntityClass.RelationshipEntity1, objectId, CollisionType.Delete, null, DateTime.MinValue);
					default:
						return null;
				}
			}
			catch (SqlException e)
			{
				throw new DALException(RepositoryExceptionMessage.UnexpectedExceptionDetected, e);
			}
			finally
			{
				AfterCommandExecute();
			}
		}


		public override void DeleteRelationshipEntity1(IRelationshipEntity1 relationshipEntity1)
		{
			DeleteRelationshipEntity1Core(relationshipEntity1, this.ignoreCollision);
		}

		public override void DeleteRelationshipEntity1(IRelationshipEntity1 relationshipEntity1, bool ignoreCollision)
		{
			DeleteRelationshipEntity1Core(relationshipEntity1, ignoreCollision);
		}

		protected override void DeleteRelationshipEntity1Core(IRelationshipEntity1 relationshipEntity1, bool ignoreCollision)
		{
			// When transaction support is added, ApplySaveLog must not be called if an exception is encountered.
			SaveLog saveLog = new SaveLog();
			try
			{
				DeleteRelationshipEntity1Core(relationshipEntity1, ignoreCollision, saveLog);
				saveLog.ApplySaveLog();
			}
			catch (Exception)
			{
				// Still call ApplySaveLog because no support for transaction/rollback yet.
				saveLog.ApplySaveLog();
				throw;
			}
		}

		// Because cascade delete operations are handled at the DB level, this implementation of this function is trivial.
		protected override void DeleteRelationshipEntity1Core(IRelationshipEntity1 relationshipEntity1, bool ignoreCollision, SaveLog saveLog)
		{
			DeleteRelationshipEntity1EntityObjectCore(relationshipEntity1, ignoreCollision, saveLog);
		}

		protected override void DeleteRelationshipEntity1EntityObjectCore(IRelationshipEntity1 relationshipEntity1, bool ignoreCollision, SaveLog saveLog)
		{
			SaveLogEntry saveLogEntry = new SaveLogEntry();
			// These saveLogEntry assignments must occur here so that they are set if an exception occurs.
			saveLogEntry.EntityObject = relationshipEntity1;
			saveLogEntry.PreSaveObjectStatus = relationshipEntity1.ObjectStatus;
			try
			{
				saveLogEntry.RepositoryUpdateOperation = RepositoryUpdateOperation.Delete;

				DeleteRelationshipEntity1((RelationshipEntity1Identifier)relationshipEntity1.ObjectId, relationshipEntity1.UpdateId, ignoreCollision);

				saveLogEntry.PostSaveObjectStatus = ObjectStatus.Deleted;
				saveLog.Add(saveLogEntry);
				// Add SaveLog entries for in-memory objects owned by relationshipEntity1 that must have been cascade deleted by the repository.
				saveLog.UpdateSaveLogForCascadeDelete((IEntityObject)relationshipEntity1);
			}
			catch (SingleCollisionException e)
			{
				// Update the object's status to reflect the collision.
				if (e.Collision.CollisionType == CollisionType.Delete)
					// Collision - object physically deleted by another user.
					saveLogEntry.PostSaveObjectStatus = ObjectStatus.Deleted;
				else if (e.Collision.CollisionType == CollisionType.Update)
					// Collision - object updated by another user.
					saveLogEntry.PostSaveObjectStatus = ObjectStatus.Outdated;
				saveLog.Add(saveLogEntry);
				if (e.Collision.CollisionType == CollisionType.Delete)
				{
					saveLog.UpdateSaveLogForCascadeDelete((IEntityObject)relationshipEntity1);
				}
				// Rethrow the collision exception.
				throw;
			}
		}

		public override void DeleteRelationshipEntity1(RelationshipEntity1Identifier objectId, int updateId)
		{
			DeleteRelationshipEntity1Core(objectId, updateId, this.ignoreCollision);
		}

		public override void DeleteRelationshipEntity1(RelationshipEntity1Identifier objectId, int updateId, bool ignoreCollision)
		{
			DeleteRelationshipEntity1Core(objectId, updateId, ignoreCollision);
		}

		protected override void DeleteRelationshipEntity1Core(RelationshipEntity1Identifier objectId, int updateId, bool ignoreCollision)
		{
			try
			{
				if (this.relationshipEntity1DeleteCmd == null) CreateRelationshipEntity1DeleteCommand();
				SqlCommand cmd = this.relationshipEntity1DeleteCmd;

				// Set input parameters specific to the delete operation.

				cmd.Parameters["@p_relationship_entity_1_id"].Value = objectId.RelationshipEntity1Id;
				if (ignoreCollision)
					cmd.Parameters["@p_ignore_collision_"].Value = 1;
				else
					cmd.Parameters["@p_ignore_collision_"].Value = 0;
				cmd.Parameters["@p_update_id_"].Value = updateId;

				// Call stored procedure.
				BeforeCommandExecute();
				cmd.ExecuteNonQuery();

				// Process results.

				switch ((int)cmd.Parameters["@p_rc_"].Value)
				{
					case 1: // Update successful.
						break;
					case 2: // Collision - object updated by another user.
						throw new SingleCollisionException(RepositoryExceptionMessage.UpdateCollisionDetected, EntityClass.RelationshipEntity1, objectId, CollisionType.Update, (string)cmd.Parameters["@p_user_"].Value, (DateTime)cmd.Parameters["@p_update_ts_"].Value);
					case 3: // Collision - object physically deleted by another user.
						throw new SingleCollisionException(RepositoryExceptionMessage.DeleteCollisionDetected, EntityClass.RelationshipEntity1, objectId, CollisionType.Delete, null, DateTime.MinValue);
				}
			}
			catch (SqlException e)
			{
				throw new DALException(RepositoryExceptionMessage.UnexpectedExceptionDetected, e);
			}
			finally
			{
				AfterCommandExecute();
			}
		}


		public override void SaveRelationshipEntity1(IRelationshipEntity1 relationshipEntity1)
		{
			SaveRelationshipEntity1Core(relationshipEntity1, this.ignoreCollision);
		}

		public override void SaveRelationshipEntity1(IRelationshipEntity1 relationshipEntity1, bool ignoreCollision)
		{
			SaveRelationshipEntity1Core(relationshipEntity1, ignoreCollision);
		}

		protected override void SaveRelationshipEntity1Core(IRelationshipEntity1 relationshipEntity1, bool ignoreCollision)
		{
			// When transaction support is added, ApplySaveLog must not be called if an exception is encountered.
			SaveLog saveLog = new SaveLog();
			try
			{
				SaveRelationshipEntity1Core(relationshipEntity1, ignoreCollision, saveLog);
				saveLog.ApplySaveLog();
			}
			catch (Exception)
			{
				// Still call ApplySaveLog because no support for transaction/rollback yet.
				saveLog.ApplySaveLog();
				// Reverse the commit state set by ApplySaveLog.
				relationshipEntity1.HasUncommittedChanges = true; // This line ensures that errors in saving dependent entities don't result in the parent being marked as uncommitted (because it isn't).
				throw;
			}
		}

		// The core function for saving a specific RelationshipEntity1 instance as well as related entity objects.
		// If an object is marked for deletion, this function calls DeleteRelationshipEntity1Core.
		// This function must NEVER update any properties of the entity object (relationshipEntity1).
		// Such updates must be cached in saveLog and applied by the caller depending upon whether or not an exception occurred and if the update is part of a transaction.
		protected override void SaveRelationshipEntity1Core(IRelationshipEntity1 relationshipEntity1, bool ignoreCollision, SaveLog saveLog)
		{
			if (relationshipEntity1.MarkedForDeletion)
			{
				// Database level cascade delete will take care of whatever dependent and relation entities are associated with RelationshipEntity1.
				DeleteRelationshipEntity1Core(relationshipEntity1, ignoreCollision, saveLog);
			}
			else
			{
				#region Entity Object

				bool insertOperation = SaveRelationshipEntity1EntityObjectCore(relationshipEntity1, ignoreCollision, saveLog);

				#endregion Entity Object

				#region Owned Child Entity Objects

				// This entity has no owned inbound relationships.

				#endregion Owned Child Entity Objects

			} // if (relationshipEntity1.MarkedForDeletion)
		}

		// The core function for saving a specific RelationshipEntity1 object.
		// It does not handle deletes (if the entity is marked for deletion) nor updating of related entity objects.
		// This function must NEVER update any properties of the entity object (relationshipEntity1).
		// Such updates must be cached in saveLog and applied by the caller depending upon whether or not an exception occurred and if the update is part of a transaction.
		protected override bool SaveRelationshipEntity1EntityObjectCore(IRelationshipEntity1 relationshipEntity1, bool ignoreCollision, SaveLog saveLog)
		{
			bool insertOperation;

			SaveLogEntry saveLogEntry = new SaveLogEntry();
			// These saveLogEntry assignments must occur here so that they are set if an exception occurs.
			saveLogEntry.EntityObject = relationshipEntity1;
			saveLogEntry.PreSaveObjectStatus = relationshipEntity1.ObjectStatus;

			try
			{
				insertOperation = !relationshipEntity1.ObjectId.HasValue;
				SqlCommand cmd;

				if (insertOperation)
				{
					// Have a new RelationshipEntity1 object to save.

					saveLogEntry.RepositoryUpdateOperation = RepositoryUpdateOperation.Insert;

					if (this.relationshipEntity1InsertCmd == null) CreateRelationshipEntity1InsertCommand();
					cmd = this.relationshipEntity1InsertCmd;
				}
				else
				{
					// Have a previously saved RelationshipEntity1 object to save.

					saveLogEntry.RepositoryUpdateOperation = RepositoryUpdateOperation.Update;

					if (this.relationshipEntity1UpdateCmd == null) CreateRelationshipEntity1UpdateCommand();
					cmd = this.relationshipEntity1UpdateCmd;

					// Set input parameters specific to the update operation.

					cmd.Parameters["@p_relationship_entity_1_id"].Value = relationshipEntity1.RelationshipEntity1Id.Value;
					if (ignoreCollision)
						cmd.Parameters["@p_ignore_collision_"].Value = 1;
					else
						cmd.Parameters["@p_ignore_collision_"].Value = 0;
					cmd.Parameters["@p_update_id_"].Value = relationshipEntity1.UpdateId;
				}

				// Set input parameters common to both insert and update operations.

				// [dependent_entity_2_id]
				if (relationshipEntity1.DependentEntity2Id.HasValue)
					cmd.Parameters["@p_dependent_entity_2_id"].Value = relationshipEntity1.DependentEntity2Id.Value;
				else
					cmd.Parameters["@p_dependent_entity_2_id"].Value = DBNull.Value;
				// [independent_entity_2_id]
				if (relationshipEntity1.IndependentEntity2Id.HasValue)
					cmd.Parameters["@p_independent_entity_2_id"].Value = relationshipEntity1.IndependentEntity2Id.Value;
				else
					cmd.Parameters["@p_independent_entity_2_id"].Value = DBNull.Value;
				// [attr_bool_1]
				cmd.Parameters["@p_attr_bool_1"].Value = relationshipEntity1.AttrBool1_DBObjectValue;
				// [attr_datetime_1]
				cmd.Parameters["@p_attr_datetime_1"].Value = relationshipEntity1.AttrDatetime1_DBObjectValue;
				// [attr_integer_1]
				cmd.Parameters["@p_attr_integer_1"].Value = relationshipEntity1.AttrInteger1_DBObjectValue;
				// [attr_string_1]
				cmd.Parameters["@p_attr_string_1"].Value = relationshipEntity1.AttrString1_DBObjectValue;
				// [attr_string_2]
				cmd.Parameters["@p_attr_string_2"].Value = relationshipEntity1.AttrString2_DBObjectValue;
				// [name]
				cmd.Parameters["@p_name"].Value = relationshipEntity1.Name_DBObjectValue;
				// [status]
				cmd.Parameters["@p_status"].Value = relationshipEntity1.Status_DBObjectValue;
				cmd.Parameters["@p_user_"].Value = this.user;

				// Call stored procedure.
				BeforeCommandExecute();
				cmd.ExecuteNonQuery();

				// Process results.
				if (insertOperation)
				{
					saveLogEntry.PostSaveObjectStatus = ObjectStatus.Existing;
					((IEditableObject)relationshipEntity1).BeginEdit();
					RelationshipEntity1Identifier identifier = new RelationshipEntity1Identifier();
					identifier.RelationshipEntity1Id = (int)cmd.Parameters["@p_relationship_entity_1_id"].Value;
					relationshipEntity1.ObjectId = identifier;
					relationshipEntity1.CreateTimestamp = (DateTime)cmd.Parameters["@p_update_ts_"].Value;
					relationshipEntity1.CreateUser = this.user;
				}
				else
				{
					int returnCode = (int)cmd.Parameters["@p_rc_"].Value;
					switch (returnCode)
					{
						case 1: // Update successful.
							saveLogEntry.PostSaveObjectStatus = ObjectStatus.Existing;
							((IEditableObject)relationshipEntity1).BeginEdit();
							relationshipEntity1.ObjectId = relationshipEntity1.ObjectId;
							relationshipEntity1.CreateTimestamp = relationshipEntity1.CreateTimestamp;
							relationshipEntity1.CreateUser = relationshipEntity1.CreateUser;
							break;
						case 2: // Collision - object updated by another user.
							throw new SingleCollisionException(RepositoryExceptionMessage.UpdateCollisionDetected, relationshipEntity1.EntityClass, relationshipEntity1.ObjectId, CollisionType.Update, (string)cmd.Parameters["@p_user_"].Value, (DateTime)cmd.Parameters["@p_update_ts_"].Value);
						case 3: // Collision - object physically deleted by another user.
							throw new SingleCollisionException(RepositoryExceptionMessage.DeleteCollisionDetected, relationshipEntity1.EntityClass, relationshipEntity1.ObjectId, CollisionType.Delete, null, DateTime.MinValue);
					}
				}
				relationshipEntity1.LastUpdateTimestamp = (DateTime)cmd.Parameters["@p_update_ts_"].Value;
				relationshipEntity1.LastUpdateUser = this.user;
				if (cmd.Parameters["@p_update_id_"].Value == DBNull.Value)
					relationshipEntity1.UpdateId = 0;
				else
					relationshipEntity1.UpdateId = (int)cmd.Parameters["@p_update_id_"].Value;
				saveLog.Add(saveLogEntry); // SaveLog takes care of calling EndEdit.
			}
			catch (SingleCollisionException e)
			{
				if (e.Collision.CollisionType == CollisionType.Delete)
					saveLogEntry.PostSaveObjectStatus = ObjectStatus.Deleted;
				else if (e.Collision.CollisionType == CollisionType.Update)
					saveLogEntry.PostSaveObjectStatus = ObjectStatus.Outdated;
				saveLog.Add(saveLogEntry);
				if (e.Collision.CollisionType == CollisionType.Delete)
					saveLog.UpdateSaveLogForCascadeDelete((IEntityObject)relationshipEntity1);
				throw;
			}
			catch (SqlException e)
			{
				throw new DALException(RepositoryExceptionMessage.UnexpectedExceptionDetected, e);
			}
			finally
			{
				AfterCommandExecute();
			}

			return insertOperation;
		}

		protected virtual IRelationshipEntity1 OnRelationshipEntity1Load(IRelationshipEntity1 relationshipEntity1)
		{
			return relationshipEntity1;
		}

		#endregion RelationshipEntity1 related members.

		#region Attachment1 related private methods.

		protected virtual IAttachment1 CreateAttachment1FromSqlDataReader(SqlDataReader sdr)
		{
			IAttachment1 attachment1 = (IAttachment1)this.classFactory.GetEntityObject(EntityClass.Attachment1);
			// Process primary key fields.
			attachment1.ObjectId = CreateAttachment1IdentifierFromSqlDataReader(sdr, 0);
			bool foundNullValue;
			// Process foreign key fields associated with the DependentEntity1 owner relationship.
			foundNullValue = sdr.IsDBNull(1); /* [dependent_entity_1_id] */
			if (foundNullValue)
			{
				attachment1.ParentOwnerDependentEntity1EntityObjectId = null;
			}
			else
			{
				DependentEntity1Identifier identifier1 = new DependentEntity1Identifier();
				// [dependent_entity_1_id] (foreign key column).
				identifier1.DependentEntity1Id = sdr.GetInt32(1);
				attachment1.ParentOwnerDependentEntity1EntityObjectId = identifier1;
			}
			// [attachment_notes] (regular column).
			if (sdr.IsDBNull(2))
				attachment1.AttachmentNotes = null;
			else
				attachment1.AttachmentNotes = sdr.GetString(2);
			// [attachment_type] (regular column).
			if (sdr.IsDBNull(3))
				attachment1.AttachmentType = null;
			else
				attachment1.AttachmentType = sdr.GetString(3);
			// [attr_bool_1] (regular column).
			if (sdr.IsDBNull(4))
				attachment1.AttrBool1 = null;
			else
				attachment1.AttrBool1 = sdr.GetBoolean(4);
			// [attr_datetime_1] (regular column).
			if (sdr.IsDBNull(5))
				attachment1.AttrDatetime1 = null;
			else
				attachment1.AttrDatetime1 = sdr.GetDateTime(5);
			// [attr_integer_1] (regular column).
			if (sdr.IsDBNull(6))
				attachment1.AttrInteger1 = null;
			else
				attachment1.AttrInteger1 = sdr.GetInt32(6);
			// [attr_string_1] (regular column).
			if (sdr.IsDBNull(7))
				attachment1.AttrString1 = null;
			else
				attachment1.AttrString1 = sdr.GetString(7);
			// [attr_string_2] (regular column).
			if (sdr.IsDBNull(8))
				attachment1.AttrString2 = null;
			else
				attachment1.AttrString2 = sdr.GetString(8);
			// [file_attachment] (blob type regular column).
			if (sdr.GetBoolean(9))
				attachment1.FileAttachment = null;
			else
			{
				// [file_name] (regular column).
				if (sdr.IsDBNull(10))
					attachment1.FileAttachment = new FileAttachment(null, new PropertyLoad(attachment1.FileAttachment_Load));
				else
					attachment1.FileAttachment = new FileAttachment(sdr.GetString(10), new PropertyLoad(attachment1.FileAttachment_Load));
			}
			// [name] (regular column).
			if (sdr.IsDBNull(11))
				attachment1.Name = null;
			else
				attachment1.Name = sdr.GetString(11);
			// [status] (regular column).
			if (sdr.IsDBNull(12))
				attachment1.Status = null;
			else
				attachment1.Status = sdr.GetString(12);
			// [create_datetime] (audit column).
			if (sdr.IsDBNull(13))
				attachment1.CreateTimestamp = null;
			else
				attachment1.CreateTimestamp = (DateTime)sdr.GetDateTime(13);
			// [create_user] (audit column).
			if (sdr.IsDBNull(14))
				attachment1.CreateUser = null;
			else
				attachment1.CreateUser = (string)sdr.GetString(14);
			// [update_datetime] (audit column).
			if (sdr.IsDBNull(15))
				attachment1.LastUpdateTimestamp = null;
			else
				attachment1.LastUpdateTimestamp = (DateTime)sdr.GetDateTime(15);
			// [update_id] (audit column).
			if (sdr.IsDBNull(16))
				attachment1.UpdateId = 0;
			else
				attachment1.UpdateId = (int)sdr.GetInt32(16);
			// [update_user] (audit column).
			if (sdr.IsDBNull(17))
				attachment1.LastUpdateUser = null;
			else
				attachment1.LastUpdateUser = (string)sdr.GetString(17);
			attachment1.ObjectStatus = ObjectStatus.Existing;
			attachment1.HasUncommittedChanges = false;
			return OnAttachment1Load(attachment1);
		}

		protected virtual Attachment1Identifier? CreateAttachment1IdentifierFromSqlDataReader(SqlDataReader sdr, int index)
		{
			bool foundNullValue;
			// Process primary key fields.
			foundNullValue = sdr.IsDBNull(index + 0); /* [attachment_1_id] */
			if (foundNullValue)
			{
				return null;
			}
			else
			{
				Attachment1Identifier identifier = new Attachment1Identifier();
				// [attachment_1_id]
				identifier.Attachment1Id = sdr.GetInt32(index + 0);
				return identifier;
			}
		}

		protected virtual void CreateAttachment1GetCommand()
		{
			SqlCommand cmd = new SqlCommand("spget_attachment_1", this.connection);
			cmd.CommandTimeout = this.commandTimeout;
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;

			// Setup input parameters.

			// Primary key properties.
			cmd.Parameters.Add("@p_attachment_1_id", System.Data.SqlDbType.Int);

			// Setup output parameters.

			// Foreign key properties.
			param = cmd.Parameters.Add("@p_dependent_entity_1_id", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;
			// Regular properties.
			param = cmd.Parameters.Add("@p_attachment_notes", System.Data.SqlDbType.NVarChar, 4000);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_attachment_type", System.Data.SqlDbType.NVarChar, 100);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_attr_bool_1", System.Data.SqlDbType.Bit);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_attr_datetime_1", System.Data.SqlDbType.DateTime);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_attr_integer_1", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_attr_string_1", System.Data.SqlDbType.NVarChar, 200);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_attr_string_2", System.Data.SqlDbType.NVarChar, 200);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_file_attachment_is_null", System.Data.SqlDbType.Bit);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_file_name", System.Data.SqlDbType.NVarChar, 350);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_name", System.Data.SqlDbType.NVarChar, 100);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_status", System.Data.SqlDbType.NVarChar, 100);
			param.Direction = ParameterDirection.Output;
			// Audit properties.
			param = cmd.Parameters.Add("@p_create_datetime", System.Data.SqlDbType.DateTime);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_create_user", System.Data.SqlDbType.NVarChar, 50);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_datetime", System.Data.SqlDbType.DateTime);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_id", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_user", System.Data.SqlDbType.NVarChar, 50);
			param.Direction = ParameterDirection.Output;
			// Return code.
			param = cmd.Parameters.Add("@p_rc_", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;

			this.attachment1GetCmd = cmd;
		}

		protected virtual void CreateAttachment1GetBLOBCommand()
		{
			SqlCommand cmd = new SqlCommand("spget_attachment_1_blob", this.connection);
			cmd.CommandTimeout = this.commandTimeout;
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;

			//  Setup input parameters.

			cmd.Parameters.Add("@p_attachment_1_id", System.Data.SqlDbType.Int);
			cmd.Parameters.Add("@p_ignore_collision_", System.Data.SqlDbType.Bit);
			cmd.Parameters.Add("@p_update_id_", System.Data.SqlDbType.Int);
			cmd.Parameters.Add("@p_column_name_", System.Data.SqlDbType.NVarChar, 128);

			// Setup output parameters.

			param = cmd.Parameters.Add("@p_rc_", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_ts_", System.Data.SqlDbType.DateTime);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_user_", System.Data.SqlDbType.NVarChar, 32);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_blob_", System.Data.SqlDbType.VarBinary, -1);
			param.Direction = ParameterDirection.Output;

			this.attachment1GetBLOBCmd = cmd;
		}

		protected virtual void CreateAttachment1InsertCommand()
		{
			SqlCommand cmd = new SqlCommand("spinsert_attachment_1", this.connection);
			cmd.CommandTimeout = this.commandTimeout;
			cmd.CommandType = CommandType.StoredProcedure;

			// Setup input parameters.

			SqlParameter param;
			// Foreign key properties.
			cmd.Parameters.Add("@p_dependent_entity_1_id", System.Data.SqlDbType.Int);
			// Regular properties.
			cmd.Parameters.Add("@p_attachment_notes", System.Data.SqlDbType.NVarChar, 4000);
			cmd.Parameters.Add("@p_attachment_type", System.Data.SqlDbType.NVarChar, 100);
			cmd.Parameters.Add("@p_attr_bool_1", System.Data.SqlDbType.Bit);
			cmd.Parameters.Add("@p_attr_datetime_1", System.Data.SqlDbType.DateTime);
			cmd.Parameters.Add("@p_attr_integer_1", System.Data.SqlDbType.Int);
			cmd.Parameters.Add("@p_attr_string_1", System.Data.SqlDbType.NVarChar, 200);
			cmd.Parameters.Add("@p_attr_string_2", System.Data.SqlDbType.NVarChar, 200);
			cmd.Parameters.Add("@p_file_attachment", System.Data.SqlDbType.VarBinary, -1);
			cmd.Parameters.Add("@p_file_name", System.Data.SqlDbType.NVarChar, 350);
			cmd.Parameters.Add("@p_name", System.Data.SqlDbType.NVarChar, 100);
			cmd.Parameters.Add("@p_status", System.Data.SqlDbType.NVarChar, 100);
			// Audit properties.
			cmd.Parameters.Add("@p_user_", System.Data.SqlDbType.NVarChar, 50);

			// Setup output parameters.

			param = cmd.Parameters.Add("@p_attachment_1_id", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_ts_", System.Data.SqlDbType.DateTime);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_id_", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;

			this.attachment1InsertCmd = cmd;
		}

		protected virtual void CreateAttachment1DeleteCommand()
		{
			SqlCommand cmd = new SqlCommand("spdelete_attachment_1", this.connection);
			cmd.CommandTimeout = this.commandTimeout;
			cmd.CommandType = CommandType.StoredProcedure;

			// Setup input parameters.

			// Primary key properties.
			cmd.Parameters.Add("@p_attachment_1_id", System.Data.SqlDbType.Int);
			cmd.Parameters.Add("@p_ignore_collision_", System.Data.SqlDbType.Bit);
			cmd.Parameters.Add("@p_update_id_", System.Data.SqlDbType.Int);

			// Setup output parameters.

			SqlParameter param;
			param = cmd.Parameters.Add("@p_rc_", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_ts_", System.Data.SqlDbType.DateTime);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_user_", System.Data.SqlDbType.NVarChar, 50);
			param.Direction = ParameterDirection.Output;

			this.attachment1DeleteCmd = cmd;
		}

		protected virtual void CreateAttachment1UpdateCommand()
		{
			SqlCommand cmd = new SqlCommand("spupdate_attachment_1", this.connection);
			cmd.CommandTimeout = this.commandTimeout;
			cmd.CommandType = CommandType.StoredProcedure;

			// Setup input parameters.

			SqlParameter param;
			// Primary key properties.
			cmd.Parameters.Add("@p_attachment_1_id", System.Data.SqlDbType.Int);
			// Foreign key properties.
			cmd.Parameters.Add("@p_dependent_entity_1_id", System.Data.SqlDbType.Int);
			// Regular properties.
			cmd.Parameters.Add("@p_attachment_notes", System.Data.SqlDbType.NVarChar, 4000);
			cmd.Parameters.Add("@p_attachment_type", System.Data.SqlDbType.NVarChar, 100);
			cmd.Parameters.Add("@p_attr_bool_1", System.Data.SqlDbType.Bit);
			cmd.Parameters.Add("@p_attr_datetime_1", System.Data.SqlDbType.DateTime);
			cmd.Parameters.Add("@p_attr_integer_1", System.Data.SqlDbType.Int);
			cmd.Parameters.Add("@p_attr_string_1", System.Data.SqlDbType.NVarChar, 200);
			cmd.Parameters.Add("@p_attr_string_2", System.Data.SqlDbType.NVarChar, 200);
			cmd.Parameters.Add("@p_file_attachment", System.Data.SqlDbType.VarBinary, -1);
			cmd.Parameters.Add("@p_file_name", System.Data.SqlDbType.NVarChar, 350);
			cmd.Parameters.Add("@p_file_attachment_no_update", System.Data.SqlDbType.Bit);
			cmd.Parameters.Add("@p_name", System.Data.SqlDbType.NVarChar, 100);
			cmd.Parameters.Add("@p_status", System.Data.SqlDbType.NVarChar, 100);
			cmd.Parameters.Add("@p_ignore_collision_", System.Data.SqlDbType.Bit);

			// Setup output parameters.

			param = cmd.Parameters.Add("@p_rc_", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_ts_", System.Data.SqlDbType.DateTime);
			param.Direction = ParameterDirection.Output;

			// Setup input-output parameters.

			param = cmd.Parameters.Add("@p_user_", System.Data.SqlDbType.NVarChar, 50);
			param.Direction = ParameterDirection.InputOutput;
			param = cmd.Parameters.Add("@p_update_id_", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.InputOutput;

			this.attachment1UpdateCmd = cmd;
		}

		#endregion Attachment1 related private methods.

		#region DependentEntity1 related private methods.

		protected virtual IDependentEntity1 CreateDependentEntity1FromSqlDataReader(SqlDataReader sdr)
		{
			IDependentEntity1 dependentEntity1 = (IDependentEntity1)this.classFactory.GetEntityObject(EntityClass.DependentEntity1);
			// Process primary key fields.
			dependentEntity1.ObjectId = CreateDependentEntity1IdentifierFromSqlDataReader(sdr, 0);
			bool foundNullValue;
			// Process foreign key fields associated with the IndependentEntity1 owner relationship.
			foundNullValue = sdr.IsDBNull(1); /* [independent_entity_1_id] */
			if (foundNullValue)
			{
				dependentEntity1.ParentOwnerIndependentEntity1EntityObjectId = null;
			}
			else
			{
				IndependentEntity1Identifier identifier1 = new IndependentEntity1Identifier();
				// [independent_entity_1_id] (foreign key column).
				identifier1.IndependentEntity1Id = sdr.GetInt32(1);
				dependentEntity1.ParentOwnerIndependentEntity1EntityObjectId = identifier1;
			}
			// [attr_bool_1] (regular column).
			if (sdr.IsDBNull(2))
				dependentEntity1.AttrBool1 = null;
			else
				dependentEntity1.AttrBool1 = sdr.GetBoolean(2);
			// [attr_datetime_1] (regular column).
			if (sdr.IsDBNull(3))
				dependentEntity1.AttrDatetime1 = null;
			else
				dependentEntity1.AttrDatetime1 = sdr.GetDateTime(3);
			// [attr_integer_1] (regular column).
			if (sdr.IsDBNull(4))
				dependentEntity1.AttrInteger1 = null;
			else
				dependentEntity1.AttrInteger1 = sdr.GetInt32(4);
			// [attr_string_1] (regular column).
			if (sdr.IsDBNull(5))
				dependentEntity1.AttrString1 = null;
			else
				dependentEntity1.AttrString1 = sdr.GetString(5);
			// [attr_string_2] (regular column).
			if (sdr.IsDBNull(6))
				dependentEntity1.AttrString2 = null;
			else
				dependentEntity1.AttrString2 = sdr.GetString(6);
			// [name] (regular column).
			if (sdr.IsDBNull(7))
				dependentEntity1.Name = null;
			else
				dependentEntity1.Name = sdr.GetString(7);
			// [status] (regular column).
			if (sdr.IsDBNull(8))
				dependentEntity1.Status = null;
			else
				dependentEntity1.Status = sdr.GetString(8);
			// [create_datetime] (audit column).
			if (sdr.IsDBNull(9))
				dependentEntity1.CreateTimestamp = null;
			else
				dependentEntity1.CreateTimestamp = (DateTime)sdr.GetDateTime(9);
			// [create_user] (audit column).
			if (sdr.IsDBNull(10))
				dependentEntity1.CreateUser = null;
			else
				dependentEntity1.CreateUser = (string)sdr.GetString(10);
			// [update_datetime] (audit column).
			if (sdr.IsDBNull(11))
				dependentEntity1.LastUpdateTimestamp = null;
			else
				dependentEntity1.LastUpdateTimestamp = (DateTime)sdr.GetDateTime(11);
			// [update_id] (audit column).
			if (sdr.IsDBNull(12))
				dependentEntity1.UpdateId = 0;
			else
				dependentEntity1.UpdateId = (int)sdr.GetInt32(12);
			// [update_user] (audit column).
			if (sdr.IsDBNull(13))
				dependentEntity1.LastUpdateUser = null;
			else
				dependentEntity1.LastUpdateUser = (string)sdr.GetString(13);
			dependentEntity1.ObjectStatus = ObjectStatus.Existing;
			dependentEntity1.HasUncommittedChanges = false;
			return OnDependentEntity1Load(dependentEntity1);
		}

		protected virtual DependentEntity1Identifier? CreateDependentEntity1IdentifierFromSqlDataReader(SqlDataReader sdr, int index)
		{
			bool foundNullValue;
			// Process primary key fields.
			foundNullValue = sdr.IsDBNull(index + 0); /* [dependent_entity_1_id] */
			if (foundNullValue)
			{
				return null;
			}
			else
			{
				DependentEntity1Identifier identifier = new DependentEntity1Identifier();
				// [dependent_entity_1_id]
				identifier.DependentEntity1Id = sdr.GetInt32(index + 0);
				return identifier;
			}
		}

		protected virtual void CreateDependentEntity1GetCommand()
		{
			SqlCommand cmd = new SqlCommand("spget_dependent_entity_1", this.connection);
			cmd.CommandTimeout = this.commandTimeout;
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;

			// Setup input parameters.

			// Primary key properties.
			cmd.Parameters.Add("@p_dependent_entity_1_id", System.Data.SqlDbType.Int);

			// Setup output parameters.

			// Foreign key properties.
			param = cmd.Parameters.Add("@p_independent_entity_1_id", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;
			// Regular properties.
			param = cmd.Parameters.Add("@p_attr_bool_1", System.Data.SqlDbType.Bit);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_attr_datetime_1", System.Data.SqlDbType.DateTime);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_attr_integer_1", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_attr_string_1", System.Data.SqlDbType.NVarChar, 200);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_attr_string_2", System.Data.SqlDbType.NVarChar, 200);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_name", System.Data.SqlDbType.NVarChar, 100);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_status", System.Data.SqlDbType.NVarChar, 100);
			param.Direction = ParameterDirection.Output;
			// Audit properties.
			param = cmd.Parameters.Add("@p_create_datetime", System.Data.SqlDbType.DateTime);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_create_user", System.Data.SqlDbType.NVarChar, 50);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_datetime", System.Data.SqlDbType.DateTime);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_id", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_user", System.Data.SqlDbType.NVarChar, 50);
			param.Direction = ParameterDirection.Output;
			// Return code.
			param = cmd.Parameters.Add("@p_rc_", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;

			this.dependentEntity1GetCmd = cmd;
		}

		protected virtual void CreateDependentEntity1GetBLOBCommand()
		{
			SqlCommand cmd = new SqlCommand("spget_dependent_entity_1_blob", this.connection);
			cmd.CommandTimeout = this.commandTimeout;
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;

			//  Setup input parameters.

			cmd.Parameters.Add("@p_dependent_entity_1_id", System.Data.SqlDbType.Int);
			cmd.Parameters.Add("@p_ignore_collision_", System.Data.SqlDbType.Bit);
			cmd.Parameters.Add("@p_update_id_", System.Data.SqlDbType.Int);
			cmd.Parameters.Add("@p_column_name_", System.Data.SqlDbType.NVarChar, 128);

			// Setup output parameters.

			param = cmd.Parameters.Add("@p_rc_", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_ts_", System.Data.SqlDbType.DateTime);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_user_", System.Data.SqlDbType.NVarChar, 32);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_blob_", System.Data.SqlDbType.VarBinary, -1);
			param.Direction = ParameterDirection.Output;

			this.dependentEntity1GetBLOBCmd = cmd;
		}

		protected virtual void CreateDependentEntity1InsertCommand()
		{
			SqlCommand cmd = new SqlCommand("spinsert_dependent_entity_1", this.connection);
			cmd.CommandTimeout = this.commandTimeout;
			cmd.CommandType = CommandType.StoredProcedure;

			// Setup input parameters.

			SqlParameter param;
			// Foreign key properties.
			cmd.Parameters.Add("@p_independent_entity_1_id", System.Data.SqlDbType.Int);
			// Regular properties.
			cmd.Parameters.Add("@p_attr_bool_1", System.Data.SqlDbType.Bit);
			cmd.Parameters.Add("@p_attr_datetime_1", System.Data.SqlDbType.DateTime);
			cmd.Parameters.Add("@p_attr_integer_1", System.Data.SqlDbType.Int);
			cmd.Parameters.Add("@p_attr_string_1", System.Data.SqlDbType.NVarChar, 200);
			cmd.Parameters.Add("@p_attr_string_2", System.Data.SqlDbType.NVarChar, 200);
			cmd.Parameters.Add("@p_name", System.Data.SqlDbType.NVarChar, 100);
			cmd.Parameters.Add("@p_status", System.Data.SqlDbType.NVarChar, 100);
			// Audit properties.
			cmd.Parameters.Add("@p_user_", System.Data.SqlDbType.NVarChar, 50);

			// Setup output parameters.

			param = cmd.Parameters.Add("@p_dependent_entity_1_id", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_ts_", System.Data.SqlDbType.DateTime);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_id_", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;

			this.dependentEntity1InsertCmd = cmd;
		}

		protected virtual void CreateDependentEntity1DeleteCommand()
		{
			SqlCommand cmd = new SqlCommand("spdelete_dependent_entity_1", this.connection);
			cmd.CommandTimeout = this.commandTimeout;
			cmd.CommandType = CommandType.StoredProcedure;

			// Setup input parameters.

			// Primary key properties.
			cmd.Parameters.Add("@p_dependent_entity_1_id", System.Data.SqlDbType.Int);
			cmd.Parameters.Add("@p_ignore_collision_", System.Data.SqlDbType.Bit);
			cmd.Parameters.Add("@p_update_id_", System.Data.SqlDbType.Int);

			// Setup output parameters.

			SqlParameter param;
			param = cmd.Parameters.Add("@p_rc_", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_ts_", System.Data.SqlDbType.DateTime);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_user_", System.Data.SqlDbType.NVarChar, 50);
			param.Direction = ParameterDirection.Output;

			this.dependentEntity1DeleteCmd = cmd;
		}

		protected virtual void CreateDependentEntity1UpdateCommand()
		{
			SqlCommand cmd = new SqlCommand("spupdate_dependent_entity_1", this.connection);
			cmd.CommandTimeout = this.commandTimeout;
			cmd.CommandType = CommandType.StoredProcedure;

			// Setup input parameters.

			SqlParameter param;
			// Primary key properties.
			cmd.Parameters.Add("@p_dependent_entity_1_id", System.Data.SqlDbType.Int);
			// Foreign key properties.
			cmd.Parameters.Add("@p_independent_entity_1_id", System.Data.SqlDbType.Int);
			// Regular properties.
			cmd.Parameters.Add("@p_attr_bool_1", System.Data.SqlDbType.Bit);
			cmd.Parameters.Add("@p_attr_datetime_1", System.Data.SqlDbType.DateTime);
			cmd.Parameters.Add("@p_attr_integer_1", System.Data.SqlDbType.Int);
			cmd.Parameters.Add("@p_attr_string_1", System.Data.SqlDbType.NVarChar, 200);
			cmd.Parameters.Add("@p_attr_string_2", System.Data.SqlDbType.NVarChar, 200);
			cmd.Parameters.Add("@p_name", System.Data.SqlDbType.NVarChar, 100);
			cmd.Parameters.Add("@p_status", System.Data.SqlDbType.NVarChar, 100);
			cmd.Parameters.Add("@p_ignore_collision_", System.Data.SqlDbType.Bit);

			// Setup output parameters.

			param = cmd.Parameters.Add("@p_rc_", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_ts_", System.Data.SqlDbType.DateTime);
			param.Direction = ParameterDirection.Output;

			// Setup input-output parameters.

			param = cmd.Parameters.Add("@p_user_", System.Data.SqlDbType.NVarChar, 50);
			param.Direction = ParameterDirection.InputOutput;
			param = cmd.Parameters.Add("@p_update_id_", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.InputOutput;

			this.dependentEntity1UpdateCmd = cmd;
		}

		#endregion DependentEntity1 related private methods.

		#region DependentEntity2 related private methods.

		protected virtual IDependentEntity2 CreateDependentEntity2FromSqlDataReader(SqlDataReader sdr)
		{
			IDependentEntity2 dependentEntity2 = (IDependentEntity2)this.classFactory.GetEntityObject(EntityClass.DependentEntity2);
			// Process primary key fields.
			dependentEntity2.ObjectId = CreateDependentEntity2IdentifierFromSqlDataReader(sdr, 0);
			bool foundNullValue;
			// Process foreign key fields associated with the DependentEntity1 owner relationship.
			foundNullValue = sdr.IsDBNull(1); /* [dependent_entity_1_id] */
			if (foundNullValue)
			{
				dependentEntity2.ParentOwnerDependentEntity1EntityObjectId = null;
			}
			else
			{
				DependentEntity1Identifier identifier1 = new DependentEntity1Identifier();
				// [dependent_entity_1_id] (foreign key column).
				identifier1.DependentEntity1Id = sdr.GetInt32(1);
				dependentEntity2.ParentOwnerDependentEntity1EntityObjectId = identifier1;
			}
			// [attr_bool_1] (regular column).
			if (sdr.IsDBNull(2))
				dependentEntity2.AttrBool1 = null;
			else
				dependentEntity2.AttrBool1 = sdr.GetBoolean(2);
			// [attr_datetime_1] (regular column).
			if (sdr.IsDBNull(3))
				dependentEntity2.AttrDatetime1 = null;
			else
				dependentEntity2.AttrDatetime1 = sdr.GetDateTime(3);
			// [attr_integer_1] (regular column).
			if (sdr.IsDBNull(4))
				dependentEntity2.AttrInteger1 = null;
			else
				dependentEntity2.AttrInteger1 = sdr.GetInt32(4);
			// [attr_string_1] (regular column).
			if (sdr.IsDBNull(5))
				dependentEntity2.AttrString1 = null;
			else
				dependentEntity2.AttrString1 = sdr.GetString(5);
			// [attr_string_2] (regular column).
			if (sdr.IsDBNull(6))
				dependentEntity2.AttrString2 = null;
			else
				dependentEntity2.AttrString2 = sdr.GetString(6);
			// [name] (regular column).
			if (sdr.IsDBNull(7))
				dependentEntity2.Name = null;
			else
				dependentEntity2.Name = sdr.GetString(7);
			// [status] (regular column).
			if (sdr.IsDBNull(8))
				dependentEntity2.Status = null;
			else
				dependentEntity2.Status = sdr.GetString(8);
			// [create_datetime] (audit column).
			if (sdr.IsDBNull(9))
				dependentEntity2.CreateTimestamp = null;
			else
				dependentEntity2.CreateTimestamp = (DateTime)sdr.GetDateTime(9);
			// [create_user] (audit column).
			if (sdr.IsDBNull(10))
				dependentEntity2.CreateUser = null;
			else
				dependentEntity2.CreateUser = (string)sdr.GetString(10);
			// [update_datetime] (audit column).
			if (sdr.IsDBNull(11))
				dependentEntity2.LastUpdateTimestamp = null;
			else
				dependentEntity2.LastUpdateTimestamp = (DateTime)sdr.GetDateTime(11);
			// [update_id] (audit column).
			if (sdr.IsDBNull(12))
				dependentEntity2.UpdateId = 0;
			else
				dependentEntity2.UpdateId = (int)sdr.GetInt32(12);
			// [update_user] (audit column).
			if (sdr.IsDBNull(13))
				dependentEntity2.LastUpdateUser = null;
			else
				dependentEntity2.LastUpdateUser = (string)sdr.GetString(13);
			dependentEntity2.ObjectStatus = ObjectStatus.Existing;
			dependentEntity2.HasUncommittedChanges = false;
			return OnDependentEntity2Load(dependentEntity2);
		}

		protected virtual DependentEntity2Identifier? CreateDependentEntity2IdentifierFromSqlDataReader(SqlDataReader sdr, int index)
		{
			bool foundNullValue;
			// Process primary key fields.
			foundNullValue = sdr.IsDBNull(index + 0); /* [dependent_entity_2_id] */
			if (foundNullValue)
			{
				return null;
			}
			else
			{
				DependentEntity2Identifier identifier = new DependentEntity2Identifier();
				// [dependent_entity_2_id]
				identifier.DependentEntity2Id = sdr.GetInt32(index + 0);
				return identifier;
			}
		}

		protected virtual void CreateDependentEntity2GetCommand()
		{
			SqlCommand cmd = new SqlCommand("spget_dependent_entity_2", this.connection);
			cmd.CommandTimeout = this.commandTimeout;
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;

			// Setup input parameters.

			// Primary key properties.
			cmd.Parameters.Add("@p_dependent_entity_2_id", System.Data.SqlDbType.Int);

			// Setup output parameters.

			// Foreign key properties.
			param = cmd.Parameters.Add("@p_dependent_entity_1_id", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;
			// Regular properties.
			param = cmd.Parameters.Add("@p_attr_bool_1", System.Data.SqlDbType.Bit);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_attr_datetime_1", System.Data.SqlDbType.DateTime);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_attr_integer_1", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_attr_string_1", System.Data.SqlDbType.NVarChar, 200);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_attr_string_2", System.Data.SqlDbType.NVarChar, 200);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_name", System.Data.SqlDbType.NVarChar, 100);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_status", System.Data.SqlDbType.NVarChar, 100);
			param.Direction = ParameterDirection.Output;
			// Audit properties.
			param = cmd.Parameters.Add("@p_create_datetime", System.Data.SqlDbType.DateTime);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_create_user", System.Data.SqlDbType.NVarChar, 50);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_datetime", System.Data.SqlDbType.DateTime);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_id", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_user", System.Data.SqlDbType.NVarChar, 50);
			param.Direction = ParameterDirection.Output;
			// Return code.
			param = cmd.Parameters.Add("@p_rc_", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;

			this.dependentEntity2GetCmd = cmd;
		}

		protected virtual void CreateDependentEntity2GetBLOBCommand()
		{
			SqlCommand cmd = new SqlCommand("spget_dependent_entity_2_blob", this.connection);
			cmd.CommandTimeout = this.commandTimeout;
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;

			//  Setup input parameters.

			cmd.Parameters.Add("@p_dependent_entity_2_id", System.Data.SqlDbType.Int);
			cmd.Parameters.Add("@p_ignore_collision_", System.Data.SqlDbType.Bit);
			cmd.Parameters.Add("@p_update_id_", System.Data.SqlDbType.Int);
			cmd.Parameters.Add("@p_column_name_", System.Data.SqlDbType.NVarChar, 128);

			// Setup output parameters.

			param = cmd.Parameters.Add("@p_rc_", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_ts_", System.Data.SqlDbType.DateTime);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_user_", System.Data.SqlDbType.NVarChar, 32);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_blob_", System.Data.SqlDbType.VarBinary, -1);
			param.Direction = ParameterDirection.Output;

			this.dependentEntity2GetBLOBCmd = cmd;
		}

		protected virtual void CreateDependentEntity2InsertCommand()
		{
			SqlCommand cmd = new SqlCommand("spinsert_dependent_entity_2", this.connection);
			cmd.CommandTimeout = this.commandTimeout;
			cmd.CommandType = CommandType.StoredProcedure;

			// Setup input parameters.

			SqlParameter param;
			// Foreign key properties.
			cmd.Parameters.Add("@p_dependent_entity_1_id", System.Data.SqlDbType.Int);
			// Regular properties.
			cmd.Parameters.Add("@p_attr_bool_1", System.Data.SqlDbType.Bit);
			cmd.Parameters.Add("@p_attr_datetime_1", System.Data.SqlDbType.DateTime);
			cmd.Parameters.Add("@p_attr_integer_1", System.Data.SqlDbType.Int);
			cmd.Parameters.Add("@p_attr_string_1", System.Data.SqlDbType.NVarChar, 200);
			cmd.Parameters.Add("@p_attr_string_2", System.Data.SqlDbType.NVarChar, 200);
			cmd.Parameters.Add("@p_name", System.Data.SqlDbType.NVarChar, 100);
			cmd.Parameters.Add("@p_status", System.Data.SqlDbType.NVarChar, 100);
			// Audit properties.
			cmd.Parameters.Add("@p_user_", System.Data.SqlDbType.NVarChar, 50);

			// Setup output parameters.

			param = cmd.Parameters.Add("@p_dependent_entity_2_id", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_ts_", System.Data.SqlDbType.DateTime);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_id_", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;

			this.dependentEntity2InsertCmd = cmd;
		}

		protected virtual void CreateDependentEntity2DeleteCommand()
		{
			SqlCommand cmd = new SqlCommand("spdelete_dependent_entity_2", this.connection);
			cmd.CommandTimeout = this.commandTimeout;
			cmd.CommandType = CommandType.StoredProcedure;

			// Setup input parameters.

			// Primary key properties.
			cmd.Parameters.Add("@p_dependent_entity_2_id", System.Data.SqlDbType.Int);
			cmd.Parameters.Add("@p_ignore_collision_", System.Data.SqlDbType.Bit);
			cmd.Parameters.Add("@p_update_id_", System.Data.SqlDbType.Int);

			// Setup output parameters.

			SqlParameter param;
			param = cmd.Parameters.Add("@p_rc_", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_ts_", System.Data.SqlDbType.DateTime);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_user_", System.Data.SqlDbType.NVarChar, 50);
			param.Direction = ParameterDirection.Output;

			this.dependentEntity2DeleteCmd = cmd;
		}

		protected virtual void CreateDependentEntity2UpdateCommand()
		{
			SqlCommand cmd = new SqlCommand("spupdate_dependent_entity_2", this.connection);
			cmd.CommandTimeout = this.commandTimeout;
			cmd.CommandType = CommandType.StoredProcedure;

			// Setup input parameters.

			SqlParameter param;
			// Primary key properties.
			cmd.Parameters.Add("@p_dependent_entity_2_id", System.Data.SqlDbType.Int);
			// Foreign key properties.
			cmd.Parameters.Add("@p_dependent_entity_1_id", System.Data.SqlDbType.Int);
			// Regular properties.
			cmd.Parameters.Add("@p_attr_bool_1", System.Data.SqlDbType.Bit);
			cmd.Parameters.Add("@p_attr_datetime_1", System.Data.SqlDbType.DateTime);
			cmd.Parameters.Add("@p_attr_integer_1", System.Data.SqlDbType.Int);
			cmd.Parameters.Add("@p_attr_string_1", System.Data.SqlDbType.NVarChar, 200);
			cmd.Parameters.Add("@p_attr_string_2", System.Data.SqlDbType.NVarChar, 200);
			cmd.Parameters.Add("@p_name", System.Data.SqlDbType.NVarChar, 100);
			cmd.Parameters.Add("@p_status", System.Data.SqlDbType.NVarChar, 100);
			cmd.Parameters.Add("@p_ignore_collision_", System.Data.SqlDbType.Bit);

			// Setup output parameters.

			param = cmd.Parameters.Add("@p_rc_", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_ts_", System.Data.SqlDbType.DateTime);
			param.Direction = ParameterDirection.Output;

			// Setup input-output parameters.

			param = cmd.Parameters.Add("@p_user_", System.Data.SqlDbType.NVarChar, 50);
			param.Direction = ParameterDirection.InputOutput;
			param = cmd.Parameters.Add("@p_update_id_", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.InputOutput;

			this.dependentEntity2UpdateCmd = cmd;
		}

		#endregion DependentEntity2 related private methods.

		#region IndependentEntity1 related private methods.

		protected virtual IIndependentEntity1 CreateIndependentEntity1FromSqlDataReader(SqlDataReader sdr)
		{
			IIndependentEntity1 independentEntity1 = (IIndependentEntity1)this.classFactory.GetEntityObject(EntityClass.IndependentEntity1);
			// Process primary key fields.
			independentEntity1.ObjectId = CreateIndependentEntity1IdentifierFromSqlDataReader(sdr, 0);
			// [attr_bool_1] (regular column).
			if (sdr.IsDBNull(1))
				independentEntity1.AttrBool1 = null;
			else
				independentEntity1.AttrBool1 = sdr.GetBoolean(1);
			// [attr_datetime_1] (regular column).
			if (sdr.IsDBNull(2))
				independentEntity1.AttrDatetime1 = null;
			else
				independentEntity1.AttrDatetime1 = sdr.GetDateTime(2);
			// [attr_integer_1] (regular column).
			if (sdr.IsDBNull(3))
				independentEntity1.AttrInteger1 = null;
			else
				independentEntity1.AttrInteger1 = sdr.GetInt32(3);
			// [attr_string_1] (regular column).
			if (sdr.IsDBNull(4))
				independentEntity1.AttrString1 = null;
			else
				independentEntity1.AttrString1 = sdr.GetString(4);
			// [attr_string_2] (regular column).
			if (sdr.IsDBNull(5))
				independentEntity1.AttrString2 = null;
			else
				independentEntity1.AttrString2 = sdr.GetString(5);
			// [name] (regular column).
			if (sdr.IsDBNull(6))
				independentEntity1.Name = null;
			else
				independentEntity1.Name = sdr.GetString(6);
			// [status] (regular column).
			if (sdr.IsDBNull(7))
				independentEntity1.Status = null;
			else
				independentEntity1.Status = sdr.GetString(7);
			// [create_datetime] (audit column).
			if (sdr.IsDBNull(8))
				independentEntity1.CreateTimestamp = null;
			else
				independentEntity1.CreateTimestamp = (DateTime)sdr.GetDateTime(8);
			// [create_user] (audit column).
			if (sdr.IsDBNull(9))
				independentEntity1.CreateUser = null;
			else
				independentEntity1.CreateUser = (string)sdr.GetString(9);
			// [update_datetime] (audit column).
			if (sdr.IsDBNull(10))
				independentEntity1.LastUpdateTimestamp = null;
			else
				independentEntity1.LastUpdateTimestamp = (DateTime)sdr.GetDateTime(10);
			// [update_id] (audit column).
			if (sdr.IsDBNull(11))
				independentEntity1.UpdateId = 0;
			else
				independentEntity1.UpdateId = (int)sdr.GetInt32(11);
			// [update_user] (audit column).
			if (sdr.IsDBNull(12))
				independentEntity1.LastUpdateUser = null;
			else
				independentEntity1.LastUpdateUser = (string)sdr.GetString(12);
			independentEntity1.ObjectStatus = ObjectStatus.Existing;
			independentEntity1.HasUncommittedChanges = false;
			return OnIndependentEntity1Load(independentEntity1);
		}

		protected virtual IndependentEntity1Identifier? CreateIndependentEntity1IdentifierFromSqlDataReader(SqlDataReader sdr, int index)
		{
			bool foundNullValue;
			// Process primary key fields.
			foundNullValue = sdr.IsDBNull(index + 0); /* [independent_entity_1_id] */
			if (foundNullValue)
			{
				return null;
			}
			else
			{
				IndependentEntity1Identifier identifier = new IndependentEntity1Identifier();
				// [independent_entity_1_id]
				identifier.IndependentEntity1Id = sdr.GetInt32(index + 0);
				return identifier;
			}
		}

		protected virtual void CreateIndependentEntity1GetCommand()
		{
			SqlCommand cmd = new SqlCommand("spget_independent_entity_1", this.connection);
			cmd.CommandTimeout = this.commandTimeout;
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;

			// Setup input parameters.

			// Primary key properties.
			cmd.Parameters.Add("@p_independent_entity_1_id", System.Data.SqlDbType.Int);

			// Setup output parameters.

			// Foreign key properties.
			// Regular properties.
			param = cmd.Parameters.Add("@p_attr_bool_1", System.Data.SqlDbType.Bit);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_attr_datetime_1", System.Data.SqlDbType.DateTime);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_attr_integer_1", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_attr_string_1", System.Data.SqlDbType.NVarChar, 200);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_attr_string_2", System.Data.SqlDbType.NVarChar, 200);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_name", System.Data.SqlDbType.NVarChar, 100);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_status", System.Data.SqlDbType.NVarChar, 100);
			param.Direction = ParameterDirection.Output;
			// Audit properties.
			param = cmd.Parameters.Add("@p_create_datetime", System.Data.SqlDbType.DateTime);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_create_user", System.Data.SqlDbType.NVarChar, 50);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_datetime", System.Data.SqlDbType.DateTime);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_id", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_user", System.Data.SqlDbType.NVarChar, 50);
			param.Direction = ParameterDirection.Output;
			// Return code.
			param = cmd.Parameters.Add("@p_rc_", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;

			this.independentEntity1GetCmd = cmd;
		}

		protected virtual void CreateIndependentEntity1GetBLOBCommand()
		{
			SqlCommand cmd = new SqlCommand("spget_independent_entity_1_blob", this.connection);
			cmd.CommandTimeout = this.commandTimeout;
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;

			//  Setup input parameters.

			cmd.Parameters.Add("@p_independent_entity_1_id", System.Data.SqlDbType.Int);
			cmd.Parameters.Add("@p_ignore_collision_", System.Data.SqlDbType.Bit);
			cmd.Parameters.Add("@p_update_id_", System.Data.SqlDbType.Int);
			cmd.Parameters.Add("@p_column_name_", System.Data.SqlDbType.NVarChar, 128);

			// Setup output parameters.

			param = cmd.Parameters.Add("@p_rc_", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_ts_", System.Data.SqlDbType.DateTime);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_user_", System.Data.SqlDbType.NVarChar, 32);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_blob_", System.Data.SqlDbType.VarBinary, -1);
			param.Direction = ParameterDirection.Output;

			this.independentEntity1GetBLOBCmd = cmd;
		}

		protected virtual void CreateIndependentEntity1InsertCommand()
		{
			SqlCommand cmd = new SqlCommand("spinsert_independent_entity_1", this.connection);
			cmd.CommandTimeout = this.commandTimeout;
			cmd.CommandType = CommandType.StoredProcedure;

			// Setup input parameters.

			SqlParameter param;
			// Foreign key properties.
			// Regular properties.
			cmd.Parameters.Add("@p_attr_bool_1", System.Data.SqlDbType.Bit);
			cmd.Parameters.Add("@p_attr_datetime_1", System.Data.SqlDbType.DateTime);
			cmd.Parameters.Add("@p_attr_integer_1", System.Data.SqlDbType.Int);
			cmd.Parameters.Add("@p_attr_string_1", System.Data.SqlDbType.NVarChar, 200);
			cmd.Parameters.Add("@p_attr_string_2", System.Data.SqlDbType.NVarChar, 200);
			cmd.Parameters.Add("@p_name", System.Data.SqlDbType.NVarChar, 100);
			cmd.Parameters.Add("@p_status", System.Data.SqlDbType.NVarChar, 100);
			// Audit properties.
			cmd.Parameters.Add("@p_user_", System.Data.SqlDbType.NVarChar, 50);

			// Setup output parameters.

			param = cmd.Parameters.Add("@p_independent_entity_1_id", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_ts_", System.Data.SqlDbType.DateTime);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_id_", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;

			this.independentEntity1InsertCmd = cmd;
		}

		protected virtual void CreateIndependentEntity1DeleteCommand()
		{
			SqlCommand cmd = new SqlCommand("spdelete_independent_entity_1", this.connection);
			cmd.CommandTimeout = this.commandTimeout;
			cmd.CommandType = CommandType.StoredProcedure;

			// Setup input parameters.

			// Primary key properties.
			cmd.Parameters.Add("@p_independent_entity_1_id", System.Data.SqlDbType.Int);
			cmd.Parameters.Add("@p_ignore_collision_", System.Data.SqlDbType.Bit);
			cmd.Parameters.Add("@p_update_id_", System.Data.SqlDbType.Int);

			// Setup output parameters.

			SqlParameter param;
			param = cmd.Parameters.Add("@p_rc_", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_ts_", System.Data.SqlDbType.DateTime);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_user_", System.Data.SqlDbType.NVarChar, 50);
			param.Direction = ParameterDirection.Output;

			this.independentEntity1DeleteCmd = cmd;
		}

		protected virtual void CreateIndependentEntity1UpdateCommand()
		{
			SqlCommand cmd = new SqlCommand("spupdate_independent_entity_1", this.connection);
			cmd.CommandTimeout = this.commandTimeout;
			cmd.CommandType = CommandType.StoredProcedure;

			// Setup input parameters.

			SqlParameter param;
			// Primary key properties.
			cmd.Parameters.Add("@p_independent_entity_1_id", System.Data.SqlDbType.Int);
			// Foreign key properties.
			// Regular properties.
			cmd.Parameters.Add("@p_attr_bool_1", System.Data.SqlDbType.Bit);
			cmd.Parameters.Add("@p_attr_datetime_1", System.Data.SqlDbType.DateTime);
			cmd.Parameters.Add("@p_attr_integer_1", System.Data.SqlDbType.Int);
			cmd.Parameters.Add("@p_attr_string_1", System.Data.SqlDbType.NVarChar, 200);
			cmd.Parameters.Add("@p_attr_string_2", System.Data.SqlDbType.NVarChar, 200);
			cmd.Parameters.Add("@p_name", System.Data.SqlDbType.NVarChar, 100);
			cmd.Parameters.Add("@p_status", System.Data.SqlDbType.NVarChar, 100);
			cmd.Parameters.Add("@p_ignore_collision_", System.Data.SqlDbType.Bit);

			// Setup output parameters.

			param = cmd.Parameters.Add("@p_rc_", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_ts_", System.Data.SqlDbType.DateTime);
			param.Direction = ParameterDirection.Output;

			// Setup input-output parameters.

			param = cmd.Parameters.Add("@p_user_", System.Data.SqlDbType.NVarChar, 50);
			param.Direction = ParameterDirection.InputOutput;
			param = cmd.Parameters.Add("@p_update_id_", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.InputOutput;

			this.independentEntity1UpdateCmd = cmd;
		}

		#endregion IndependentEntity1 related private methods.

		#region IndependentEntity2 related private methods.

		protected virtual IIndependentEntity2 CreateIndependentEntity2FromSqlDataReader(SqlDataReader sdr)
		{
			IIndependentEntity2 independentEntity2 = (IIndependentEntity2)this.classFactory.GetEntityObject(EntityClass.IndependentEntity2);
			// Process primary key fields.
			independentEntity2.ObjectId = CreateIndependentEntity2IdentifierFromSqlDataReader(sdr, 0);
			// [attr_bool_1] (regular column).
			if (sdr.IsDBNull(1))
				independentEntity2.AttrBool1 = null;
			else
				independentEntity2.AttrBool1 = sdr.GetBoolean(1);
			// [attr_datetime_1] (regular column).
			if (sdr.IsDBNull(2))
				independentEntity2.AttrDatetime1 = null;
			else
				independentEntity2.AttrDatetime1 = sdr.GetDateTime(2);
			// [attr_integer_1] (regular column).
			if (sdr.IsDBNull(3))
				independentEntity2.AttrInteger1 = null;
			else
				independentEntity2.AttrInteger1 = sdr.GetInt32(3);
			// [attr_string_1] (regular column).
			if (sdr.IsDBNull(4))
				independentEntity2.AttrString1 = null;
			else
				independentEntity2.AttrString1 = sdr.GetString(4);
			// [attr_string_2] (regular column).
			if (sdr.IsDBNull(5))
				independentEntity2.AttrString2 = null;
			else
				independentEntity2.AttrString2 = sdr.GetString(5);
			// [name] (regular column).
			if (sdr.IsDBNull(6))
				independentEntity2.Name = null;
			else
				independentEntity2.Name = sdr.GetString(6);
			// [status] (regular column).
			if (sdr.IsDBNull(7))
				independentEntity2.Status = null;
			else
				independentEntity2.Status = sdr.GetString(7);
			// [create_datetime] (audit column).
			if (sdr.IsDBNull(8))
				independentEntity2.CreateTimestamp = null;
			else
				independentEntity2.CreateTimestamp = (DateTime)sdr.GetDateTime(8);
			// [create_user] (audit column).
			if (sdr.IsDBNull(9))
				independentEntity2.CreateUser = null;
			else
				independentEntity2.CreateUser = (string)sdr.GetString(9);
			// [update_datetime] (audit column).
			if (sdr.IsDBNull(10))
				independentEntity2.LastUpdateTimestamp = null;
			else
				independentEntity2.LastUpdateTimestamp = (DateTime)sdr.GetDateTime(10);
			// [update_id] (audit column).
			if (sdr.IsDBNull(11))
				independentEntity2.UpdateId = 0;
			else
				independentEntity2.UpdateId = (int)sdr.GetInt32(11);
			// [update_user] (audit column).
			if (sdr.IsDBNull(12))
				independentEntity2.LastUpdateUser = null;
			else
				independentEntity2.LastUpdateUser = (string)sdr.GetString(12);
			independentEntity2.ObjectStatus = ObjectStatus.Existing;
			independentEntity2.HasUncommittedChanges = false;
			return OnIndependentEntity2Load(independentEntity2);
		}

		protected virtual IndependentEntity2Identifier? CreateIndependentEntity2IdentifierFromSqlDataReader(SqlDataReader sdr, int index)
		{
			bool foundNullValue;
			// Process primary key fields.
			foundNullValue = sdr.IsDBNull(index + 0); /* [independent_entity_2_id] */
			if (foundNullValue)
			{
				return null;
			}
			else
			{
				IndependentEntity2Identifier identifier = new IndependentEntity2Identifier();
				// [independent_entity_2_id]
				identifier.IndependentEntity2Id = sdr.GetInt32(index + 0);
				return identifier;
			}
		}

		protected virtual void CreateIndependentEntity2GetCommand()
		{
			SqlCommand cmd = new SqlCommand("spget_independent_entity_2", this.connection);
			cmd.CommandTimeout = this.commandTimeout;
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;

			// Setup input parameters.

			// Primary key properties.
			cmd.Parameters.Add("@p_independent_entity_2_id", System.Data.SqlDbType.Int);

			// Setup output parameters.

			// Foreign key properties.
			// Regular properties.
			param = cmd.Parameters.Add("@p_attr_bool_1", System.Data.SqlDbType.Bit);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_attr_datetime_1", System.Data.SqlDbType.DateTime);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_attr_integer_1", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_attr_string_1", System.Data.SqlDbType.NVarChar, 200);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_attr_string_2", System.Data.SqlDbType.NVarChar, 200);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_name", System.Data.SqlDbType.NVarChar, 100);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_status", System.Data.SqlDbType.NVarChar, 100);
			param.Direction = ParameterDirection.Output;
			// Audit properties.
			param = cmd.Parameters.Add("@p_create_datetime", System.Data.SqlDbType.DateTime);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_create_user", System.Data.SqlDbType.NVarChar, 50);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_datetime", System.Data.SqlDbType.DateTime);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_id", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_user", System.Data.SqlDbType.NVarChar, 50);
			param.Direction = ParameterDirection.Output;
			// Return code.
			param = cmd.Parameters.Add("@p_rc_", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;

			this.independentEntity2GetCmd = cmd;
		}

		protected virtual void CreateIndependentEntity2GetBLOBCommand()
		{
			SqlCommand cmd = new SqlCommand("spget_independent_entity_2_blob", this.connection);
			cmd.CommandTimeout = this.commandTimeout;
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;

			//  Setup input parameters.

			cmd.Parameters.Add("@p_independent_entity_2_id", System.Data.SqlDbType.Int);
			cmd.Parameters.Add("@p_ignore_collision_", System.Data.SqlDbType.Bit);
			cmd.Parameters.Add("@p_update_id_", System.Data.SqlDbType.Int);
			cmd.Parameters.Add("@p_column_name_", System.Data.SqlDbType.NVarChar, 128);

			// Setup output parameters.

			param = cmd.Parameters.Add("@p_rc_", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_ts_", System.Data.SqlDbType.DateTime);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_user_", System.Data.SqlDbType.NVarChar, 32);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_blob_", System.Data.SqlDbType.VarBinary, -1);
			param.Direction = ParameterDirection.Output;

			this.independentEntity2GetBLOBCmd = cmd;
		}

		protected virtual void CreateIndependentEntity2InsertCommand()
		{
			SqlCommand cmd = new SqlCommand("spinsert_independent_entity_2", this.connection);
			cmd.CommandTimeout = this.commandTimeout;
			cmd.CommandType = CommandType.StoredProcedure;

			// Setup input parameters.

			SqlParameter param;
			// Foreign key properties.
			// Regular properties.
			cmd.Parameters.Add("@p_attr_bool_1", System.Data.SqlDbType.Bit);
			cmd.Parameters.Add("@p_attr_datetime_1", System.Data.SqlDbType.DateTime);
			cmd.Parameters.Add("@p_attr_integer_1", System.Data.SqlDbType.Int);
			cmd.Parameters.Add("@p_attr_string_1", System.Data.SqlDbType.NVarChar, 200);
			cmd.Parameters.Add("@p_attr_string_2", System.Data.SqlDbType.NVarChar, 200);
			cmd.Parameters.Add("@p_name", System.Data.SqlDbType.NVarChar, 100);
			cmd.Parameters.Add("@p_status", System.Data.SqlDbType.NVarChar, 100);
			// Audit properties.
			cmd.Parameters.Add("@p_user_", System.Data.SqlDbType.NVarChar, 50);

			// Setup output parameters.

			param = cmd.Parameters.Add("@p_independent_entity_2_id", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_ts_", System.Data.SqlDbType.DateTime);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_id_", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;

			this.independentEntity2InsertCmd = cmd;
		}

		protected virtual void CreateIndependentEntity2DeleteCommand()
		{
			SqlCommand cmd = new SqlCommand("spdelete_independent_entity_2", this.connection);
			cmd.CommandTimeout = this.commandTimeout;
			cmd.CommandType = CommandType.StoredProcedure;

			// Setup input parameters.

			// Primary key properties.
			cmd.Parameters.Add("@p_independent_entity_2_id", System.Data.SqlDbType.Int);
			cmd.Parameters.Add("@p_ignore_collision_", System.Data.SqlDbType.Bit);
			cmd.Parameters.Add("@p_update_id_", System.Data.SqlDbType.Int);

			// Setup output parameters.

			SqlParameter param;
			param = cmd.Parameters.Add("@p_rc_", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_ts_", System.Data.SqlDbType.DateTime);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_user_", System.Data.SqlDbType.NVarChar, 50);
			param.Direction = ParameterDirection.Output;

			this.independentEntity2DeleteCmd = cmd;
		}

		protected virtual void CreateIndependentEntity2UpdateCommand()
		{
			SqlCommand cmd = new SqlCommand("spupdate_independent_entity_2", this.connection);
			cmd.CommandTimeout = this.commandTimeout;
			cmd.CommandType = CommandType.StoredProcedure;

			// Setup input parameters.

			SqlParameter param;
			// Primary key properties.
			cmd.Parameters.Add("@p_independent_entity_2_id", System.Data.SqlDbType.Int);
			// Foreign key properties.
			// Regular properties.
			cmd.Parameters.Add("@p_attr_bool_1", System.Data.SqlDbType.Bit);
			cmd.Parameters.Add("@p_attr_datetime_1", System.Data.SqlDbType.DateTime);
			cmd.Parameters.Add("@p_attr_integer_1", System.Data.SqlDbType.Int);
			cmd.Parameters.Add("@p_attr_string_1", System.Data.SqlDbType.NVarChar, 200);
			cmd.Parameters.Add("@p_attr_string_2", System.Data.SqlDbType.NVarChar, 200);
			cmd.Parameters.Add("@p_name", System.Data.SqlDbType.NVarChar, 100);
			cmd.Parameters.Add("@p_status", System.Data.SqlDbType.NVarChar, 100);
			cmd.Parameters.Add("@p_ignore_collision_", System.Data.SqlDbType.Bit);

			// Setup output parameters.

			param = cmd.Parameters.Add("@p_rc_", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_ts_", System.Data.SqlDbType.DateTime);
			param.Direction = ParameterDirection.Output;

			// Setup input-output parameters.

			param = cmd.Parameters.Add("@p_user_", System.Data.SqlDbType.NVarChar, 50);
			param.Direction = ParameterDirection.InputOutput;
			param = cmd.Parameters.Add("@p_update_id_", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.InputOutput;

			this.independentEntity2UpdateCmd = cmd;
		}

		#endregion IndependentEntity2 related private methods.

		#region RelationshipEntity1 related private methods.

		protected virtual IRelationshipEntity1 CreateRelationshipEntity1FromSqlDataReader(SqlDataReader sdr)
		{
			IRelationshipEntity1 relationshipEntity1 = (IRelationshipEntity1)this.classFactory.GetEntityObject(EntityClass.RelationshipEntity1);
			// Process primary key fields.
			relationshipEntity1.ObjectId = CreateRelationshipEntity1IdentifierFromSqlDataReader(sdr, 0);
			bool foundNullValue;
			// Process foreign key fields associated with the DependentEntity2 owner relationship.
			foundNullValue = sdr.IsDBNull(1); /* [dependent_entity_2_id] */
			if (foundNullValue)
			{
				relationshipEntity1.ParentOwnerDependentEntity2EntityObjectId = null;
			}
			else
			{
				DependentEntity2Identifier identifier1 = new DependentEntity2Identifier();
				// [dependent_entity_2_id] (foreign key column).
				identifier1.DependentEntity2Id = sdr.GetInt32(1);
				relationshipEntity1.ParentOwnerDependentEntity2EntityObjectId = identifier1;
			}
			// Process foreign key fields associated with the IndependentEntity2 owner relationship.
			foundNullValue = sdr.IsDBNull(2); /* [independent_entity_2_id] */
			if (foundNullValue)
			{
				relationshipEntity1.ParentOwnerIndependentEntity2EntityObjectId = null;
			}
			else
			{
				IndependentEntity2Identifier identifier2 = new IndependentEntity2Identifier();
				// [independent_entity_2_id] (foreign key column).
				identifier2.IndependentEntity2Id = sdr.GetInt32(2);
				relationshipEntity1.ParentOwnerIndependentEntity2EntityObjectId = identifier2;
			}
			// [attr_bool_1] (regular column).
			if (sdr.IsDBNull(3))
				relationshipEntity1.AttrBool1 = null;
			else
				relationshipEntity1.AttrBool1 = sdr.GetBoolean(3);
			// [attr_datetime_1] (regular column).
			if (sdr.IsDBNull(4))
				relationshipEntity1.AttrDatetime1 = null;
			else
				relationshipEntity1.AttrDatetime1 = sdr.GetDateTime(4);
			// [attr_integer_1] (regular column).
			if (sdr.IsDBNull(5))
				relationshipEntity1.AttrInteger1 = null;
			else
				relationshipEntity1.AttrInteger1 = sdr.GetInt32(5);
			// [attr_string_1] (regular column).
			if (sdr.IsDBNull(6))
				relationshipEntity1.AttrString1 = null;
			else
				relationshipEntity1.AttrString1 = sdr.GetString(6);
			// [attr_string_2] (regular column).
			if (sdr.IsDBNull(7))
				relationshipEntity1.AttrString2 = null;
			else
				relationshipEntity1.AttrString2 = sdr.GetString(7);
			// [name] (regular column).
			if (sdr.IsDBNull(8))
				relationshipEntity1.Name = null;
			else
				relationshipEntity1.Name = sdr.GetString(8);
			// [status] (regular column).
			if (sdr.IsDBNull(9))
				relationshipEntity1.Status = null;
			else
				relationshipEntity1.Status = sdr.GetString(9);
			// [create_datetime] (audit column).
			if (sdr.IsDBNull(10))
				relationshipEntity1.CreateTimestamp = null;
			else
				relationshipEntity1.CreateTimestamp = (DateTime)sdr.GetDateTime(10);
			// [create_user] (audit column).
			if (sdr.IsDBNull(11))
				relationshipEntity1.CreateUser = null;
			else
				relationshipEntity1.CreateUser = (string)sdr.GetString(11);
			// [update_datetime] (audit column).
			if (sdr.IsDBNull(12))
				relationshipEntity1.LastUpdateTimestamp = null;
			else
				relationshipEntity1.LastUpdateTimestamp = (DateTime)sdr.GetDateTime(12);
			// [update_id] (audit column).
			if (sdr.IsDBNull(13))
				relationshipEntity1.UpdateId = 0;
			else
				relationshipEntity1.UpdateId = (int)sdr.GetInt32(13);
			// [update_user] (audit column).
			if (sdr.IsDBNull(14))
				relationshipEntity1.LastUpdateUser = null;
			else
				relationshipEntity1.LastUpdateUser = (string)sdr.GetString(14);
			relationshipEntity1.ObjectStatus = ObjectStatus.Existing;
			relationshipEntity1.HasUncommittedChanges = false;
			return OnRelationshipEntity1Load(relationshipEntity1);
		}

		protected virtual RelationshipEntity1Identifier? CreateRelationshipEntity1IdentifierFromSqlDataReader(SqlDataReader sdr, int index)
		{
			bool foundNullValue;
			// Process primary key fields.
			foundNullValue = sdr.IsDBNull(index + 0); /* [relationship_entity_1_id] */
			if (foundNullValue)
			{
				return null;
			}
			else
			{
				RelationshipEntity1Identifier identifier = new RelationshipEntity1Identifier();
				// [relationship_entity_1_id]
				identifier.RelationshipEntity1Id = sdr.GetInt32(index + 0);
				return identifier;
			}
		}

		protected virtual void CreateRelationshipEntity1GetCommand()
		{
			SqlCommand cmd = new SqlCommand("spget_relationship_entity_1", this.connection);
			cmd.CommandTimeout = this.commandTimeout;
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;

			// Setup input parameters.

			// Primary key properties.
			cmd.Parameters.Add("@p_relationship_entity_1_id", System.Data.SqlDbType.Int);

			// Setup output parameters.

			// Foreign key properties.
			param = cmd.Parameters.Add("@p_dependent_entity_2_id", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_independent_entity_2_id", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;
			// Regular properties.
			param = cmd.Parameters.Add("@p_attr_bool_1", System.Data.SqlDbType.Bit);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_attr_datetime_1", System.Data.SqlDbType.DateTime);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_attr_integer_1", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_attr_string_1", System.Data.SqlDbType.NVarChar, 200);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_attr_string_2", System.Data.SqlDbType.NVarChar, 200);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_name", System.Data.SqlDbType.NVarChar, 100);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_status", System.Data.SqlDbType.NVarChar, 100);
			param.Direction = ParameterDirection.Output;
			// Audit properties.
			param = cmd.Parameters.Add("@p_create_datetime", System.Data.SqlDbType.DateTime);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_create_user", System.Data.SqlDbType.NVarChar, 50);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_datetime", System.Data.SqlDbType.DateTime);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_id", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_user", System.Data.SqlDbType.NVarChar, 50);
			param.Direction = ParameterDirection.Output;
			// Return code.
			param = cmd.Parameters.Add("@p_rc_", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;

			this.relationshipEntity1GetCmd = cmd;
		}

		protected virtual void CreateRelationshipEntity1GetBLOBCommand()
		{
			SqlCommand cmd = new SqlCommand("spget_relationship_entity_1_blob", this.connection);
			cmd.CommandTimeout = this.commandTimeout;
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter param;

			//  Setup input parameters.

			cmd.Parameters.Add("@p_relationship_entity_1_id", System.Data.SqlDbType.Int);
			cmd.Parameters.Add("@p_ignore_collision_", System.Data.SqlDbType.Bit);
			cmd.Parameters.Add("@p_update_id_", System.Data.SqlDbType.Int);
			cmd.Parameters.Add("@p_column_name_", System.Data.SqlDbType.NVarChar, 128);

			// Setup output parameters.

			param = cmd.Parameters.Add("@p_rc_", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_ts_", System.Data.SqlDbType.DateTime);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_user_", System.Data.SqlDbType.NVarChar, 32);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_blob_", System.Data.SqlDbType.VarBinary, -1);
			param.Direction = ParameterDirection.Output;

			this.relationshipEntity1GetBLOBCmd = cmd;
		}

		protected virtual void CreateRelationshipEntity1InsertCommand()
		{
			SqlCommand cmd = new SqlCommand("spinsert_relationship_entity_1", this.connection);
			cmd.CommandTimeout = this.commandTimeout;
			cmd.CommandType = CommandType.StoredProcedure;

			// Setup input parameters.

			SqlParameter param;
			// Foreign key properties.
			cmd.Parameters.Add("@p_dependent_entity_2_id", System.Data.SqlDbType.Int);
			cmd.Parameters.Add("@p_independent_entity_2_id", System.Data.SqlDbType.Int);
			// Regular properties.
			cmd.Parameters.Add("@p_attr_bool_1", System.Data.SqlDbType.Bit);
			cmd.Parameters.Add("@p_attr_datetime_1", System.Data.SqlDbType.DateTime);
			cmd.Parameters.Add("@p_attr_integer_1", System.Data.SqlDbType.Int);
			cmd.Parameters.Add("@p_attr_string_1", System.Data.SqlDbType.NVarChar, 200);
			cmd.Parameters.Add("@p_attr_string_2", System.Data.SqlDbType.NVarChar, 200);
			cmd.Parameters.Add("@p_name", System.Data.SqlDbType.NVarChar, 100);
			cmd.Parameters.Add("@p_status", System.Data.SqlDbType.NVarChar, 100);
			// Audit properties.
			cmd.Parameters.Add("@p_user_", System.Data.SqlDbType.NVarChar, 50);

			// Setup output parameters.

			param = cmd.Parameters.Add("@p_relationship_entity_1_id", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_ts_", System.Data.SqlDbType.DateTime);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_id_", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;

			this.relationshipEntity1InsertCmd = cmd;
		}

		protected virtual void CreateRelationshipEntity1DeleteCommand()
		{
			SqlCommand cmd = new SqlCommand("spdelete_relationship_entity_1", this.connection);
			cmd.CommandTimeout = this.commandTimeout;
			cmd.CommandType = CommandType.StoredProcedure;

			// Setup input parameters.

			// Primary key properties.
			cmd.Parameters.Add("@p_relationship_entity_1_id", System.Data.SqlDbType.Int);
			cmd.Parameters.Add("@p_ignore_collision_", System.Data.SqlDbType.Bit);
			cmd.Parameters.Add("@p_update_id_", System.Data.SqlDbType.Int);

			// Setup output parameters.

			SqlParameter param;
			param = cmd.Parameters.Add("@p_rc_", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_ts_", System.Data.SqlDbType.DateTime);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_user_", System.Data.SqlDbType.NVarChar, 50);
			param.Direction = ParameterDirection.Output;

			this.relationshipEntity1DeleteCmd = cmd;
		}

		protected virtual void CreateRelationshipEntity1UpdateCommand()
		{
			SqlCommand cmd = new SqlCommand("spupdate_relationship_entity_1", this.connection);
			cmd.CommandTimeout = this.commandTimeout;
			cmd.CommandType = CommandType.StoredProcedure;

			// Setup input parameters.

			SqlParameter param;
			// Primary key properties.
			cmd.Parameters.Add("@p_relationship_entity_1_id", System.Data.SqlDbType.Int);
			// Foreign key properties.
			cmd.Parameters.Add("@p_dependent_entity_2_id", System.Data.SqlDbType.Int);
			cmd.Parameters.Add("@p_independent_entity_2_id", System.Data.SqlDbType.Int);
			// Regular properties.
			cmd.Parameters.Add("@p_attr_bool_1", System.Data.SqlDbType.Bit);
			cmd.Parameters.Add("@p_attr_datetime_1", System.Data.SqlDbType.DateTime);
			cmd.Parameters.Add("@p_attr_integer_1", System.Data.SqlDbType.Int);
			cmd.Parameters.Add("@p_attr_string_1", System.Data.SqlDbType.NVarChar, 200);
			cmd.Parameters.Add("@p_attr_string_2", System.Data.SqlDbType.NVarChar, 200);
			cmd.Parameters.Add("@p_name", System.Data.SqlDbType.NVarChar, 100);
			cmd.Parameters.Add("@p_status", System.Data.SqlDbType.NVarChar, 100);
			cmd.Parameters.Add("@p_ignore_collision_", System.Data.SqlDbType.Bit);

			// Setup output parameters.

			param = cmd.Parameters.Add("@p_rc_", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.Output;
			param = cmd.Parameters.Add("@p_update_ts_", System.Data.SqlDbType.DateTime);
			param.Direction = ParameterDirection.Output;

			// Setup input-output parameters.

			param = cmd.Parameters.Add("@p_user_", System.Data.SqlDbType.NVarChar, 50);
			param.Direction = ParameterDirection.InputOutput;
			param = cmd.Parameters.Add("@p_update_id_", System.Data.SqlDbType.Int);
			param.Direction = ParameterDirection.InputOutput;

			this.relationshipEntity1UpdateCmd = cmd;
		}

		#endregion RelationshipEntity1 related private methods.

		protected virtual void BuildWhereClause(SearchCondition searchCondition, out string whereClause, out ArrayList whereClauseParameters)
		{
			// Define variables to temporarily hold output values.
			string _whereClause = null;
			ArrayList _whereClauseParameters = null;

			// Check to see if an empty search condition has been specified.
			// If not, no further processing is required.
			bool haveSearchCondition = !(searchCondition == null || searchCondition.IsNullCondition());
			if (haveSearchCondition)
			{
				// A non empty search condition has been specified.
				_whereClause = "";
				_whereClauseParameters = new ArrayList();

				string[] separator = new string[1];
				separator[0] = SearchCondition.ParamPlaceholderString;
				string conditionText = searchCondition.GetText();
				string[] splitConditionText = conditionText.Split(separator, StringSplitOptions.None);

				SqlParameter param;
				int sqlCmdParamCount = 0;
				foreach (string s in splitConditionText)
				{
					_whereClause += s;
					if (sqlCmdParamCount < searchCondition.ConstantList.Count)
					{
						param = new SqlParameter();
						param.DbType = searchCondition.ConstantList[sqlCmdParamCount].DbType;
						if (searchCondition.ConstantList[sqlCmdParamCount].Value == null)
							param.Value = DBNull.Value;
						else
							param.Value = searchCondition.ConstantList[sqlCmdParamCount].Value;
						param.ParameterName = SearchCondition.ParamPlaceholderString + (++sqlCmdParamCount).ToString("d");
						_whereClauseParameters.Add(param);
						_whereClause += param.ParameterName;
					}
				}
			}
			// Set the output parameters.
			whereClause = _whereClause;
			whereClauseParameters = _whereClauseParameters;
		}

		protected virtual string BuildOrderByClause(SortSpecification sortSpecification)
		{
			// Check to see if a sort specification has been specified.
			// If not, no further processing is required.
			bool haveSortSpecification = !(sortSpecification == null || sortSpecification.IsNullCondition());
			if (haveSortSpecification)
				return sortSpecification.GetText();
			return
				null;
		}

	}
}
