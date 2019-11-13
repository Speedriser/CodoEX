using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustName.AppName.DAL
{
	public partial interface IAttachment1 : IEntityObject
	{
		Attachment1Identifier? ObjectId
		{
			get;
			set;
		}

		object ObjectId_DBObjectValue
		{
			get;
			set;
		}

		int? Attachment1Id
		{
			get;
		}

		object Attachment1Id_DBObjectValue
		{
			get;
		}

		string AttachmentNotes
		{
			get;
			set;
		}

		object AttachmentNotes_DBObjectValue
		{
			get;
			set;
		}

		string AttachmentType
		{
			get;
			set;
		}

		object AttachmentType_DBObjectValue
		{
			get;
			set;
		}

		bool? AttrBool1
		{
			get;
			set;
		}

		object AttrBool1_DBObjectValue
		{
			get;
			set;
		}

		bool AttrBool1_NoNull
		{
			get;
			set;
		}

		DateTime? AttrDatetime1
		{
			get;
			set;
		}

		object AttrDatetime1_DBObjectValue
		{
			get;
			set;
		}

		DateTime AttrDatetime1_NoNull
		{
			get;
			set;
		}

		int? AttrInteger1
		{
			get;
			set;
		}

		object AttrInteger1_DBObjectValue
		{
			get;
			set;
		}

		int AttrInteger1_NoNull
		{
			get;
			set;
		}

		string AttrString1
		{
			get;
			set;
		}

		object AttrString1_DBObjectValue
		{
			get;
			set;
		}

		string AttrString2
		{
			get;
			set;
		}

		object AttrString2_DBObjectValue
		{
			get;
			set;
		}

		FileAttachment FileAttachment
		{
			get;
			set;
		}

		object FileAttachment_DBObjectValue
		{
			get;
			set;
		}

		bool FileAttachment_IsLoaded
		{
			get;
			set;
		}

		void FileAttachment_Load();

		string Name
		{
			get;
			set;
		}

		object Name_DBObjectValue
		{
			get;
			set;
		}

		string Status
		{
			get;
			set;
		}

		object Status_DBObjectValue
		{
			get;
			set;
		}

		DependentEntity1Identifier? ParentOwnerDependentEntity1EntityObjectId
		{
			get;
			set;
		}

		object ParentOwnerDependentEntity1EntityObjectId_DBObjectValue
		{
			get;
			set;
		}

		int? DependentEntity1Id
		{
			get;
		}

		object DependentEntity1Id_DBObjectValue
		{
			get;
		}

		bool SameAs(IAttachment1 obj);

		// ========================================================================================================================

		#region Inbound Relationships

		#region Owned Inbound Relationships

		// This entity has no owned inbound relationships.

		#endregion // Owned Inbound Relationships

		#region Non-Owned Inbound Relationships

		// This entity has no non-owned inbound relationships.

		#endregion // Non-Owned Inbound Relationships

		#endregion // Inbound Relationships

		// ========================================================================================================================

		#region // Outbound Relationships

		#region Owner Outbound Relationships

		#region DependentEntity1 Relationship

		bool ParentOwnerDependentEntity1_Attachment1ListPartialLoadAttempted
		{
			get;
		}

		IAttachment1List ParentOwnerDependentEntity1_Attachment1List
		{
			get;
		}

		void LoadParentOwnerDependentEntity1_Attachment1List();

		void UnloadParentOwnerDependentEntity1_Attachment1List();

		IDependentEntity1 ParentOwnerDependentEntity1EntityObject
		{
			get;
		}

		bool HasParentOwnerDependentEntity1Object(bool inMemoryOnly);

		#endregion DependentEntity1 Relationship

		#endregion // Owner Outbound Relationships

		#region Non-Owner Outbound Relationships

		// This entity has no non-owner outbound relationships.

		#endregion // Non-Owner Outbound Relationships

		#endregion // Outbound Relationships

		// ========================================================================================================================

		IAttachment1 Copy(bool recurse);

		// ========================================================================================================================

		#region // Outbound Relationships Properties

		#region Owner Outbound Relationships Properties

		#region DependentEntity1 Relationship

		int? ParentOwnerDependentEntity1EntityObject_IndependentEntity1Id
		{
			get;
		}

		bool? ParentOwnerDependentEntity1EntityObject_AttrBool1
		{
			get;
		}

		DateTime? ParentOwnerDependentEntity1EntityObject_AttrDatetime1
		{
			get;
		}

		int? ParentOwnerDependentEntity1EntityObject_AttrInteger1
		{
			get;
		}

		string ParentOwnerDependentEntity1EntityObject_AttrString1
		{
			get;
		}

		string ParentOwnerDependentEntity1EntityObject_AttrString2
		{
			get;
		}

		string ParentOwnerDependentEntity1EntityObject_Name
		{
			get;
		}

		string ParentOwnerDependentEntity1EntityObject_Status
		{
			get;
		}

		#endregion DependentEntity1 Relationship Properties

		#endregion // Owner Outbound Relationships Properties

		#region Non-Owner Outbound Relationships Properties


		// This entity has no non-owner outbound relationships.

		#endregion // Non-Owner Outbound Relationships Properties

		#endregion // Outbound Relationships Properties

		// ========================================================================================================================
	}

	public partial interface IDependentEntity1 : IEntityObject
	{
		DependentEntity1Identifier? ObjectId
		{
			get;
			set;
		}

		object ObjectId_DBObjectValue
		{
			get;
			set;
		}

		int? DependentEntity1Id
		{
			get;
		}

		object DependentEntity1Id_DBObjectValue
		{
			get;
		}

		bool? AttrBool1
		{
			get;
			set;
		}

		object AttrBool1_DBObjectValue
		{
			get;
			set;
		}

		bool AttrBool1_NoNull
		{
			get;
			set;
		}

		DateTime? AttrDatetime1
		{
			get;
			set;
		}

		object AttrDatetime1_DBObjectValue
		{
			get;
			set;
		}

		DateTime AttrDatetime1_NoNull
		{
			get;
			set;
		}

		int? AttrInteger1
		{
			get;
			set;
		}

		object AttrInteger1_DBObjectValue
		{
			get;
			set;
		}

		int AttrInteger1_NoNull
		{
			get;
			set;
		}

		string AttrString1
		{
			get;
			set;
		}

		object AttrString1_DBObjectValue
		{
			get;
			set;
		}

		string AttrString2
		{
			get;
			set;
		}

		object AttrString2_DBObjectValue
		{
			get;
			set;
		}

		string Name
		{
			get;
			set;
		}

		object Name_DBObjectValue
		{
			get;
			set;
		}

		string Status
		{
			get;
			set;
		}

		object Status_DBObjectValue
		{
			get;
			set;
		}

		IndependentEntity1Identifier? ParentOwnerIndependentEntity1EntityObjectId
		{
			get;
			set;
		}

		object ParentOwnerIndependentEntity1EntityObjectId_DBObjectValue
		{
			get;
			set;
		}

		int? IndependentEntity1Id
		{
			get;
		}

		object IndependentEntity1Id_DBObjectValue
		{
			get;
		}

		bool SameAs(IDependentEntity1 obj);

		// ========================================================================================================================

		#region Inbound Relationships

		#region Owned Inbound Relationships

		#region Attachment1 Relationship

		LoadStatus ChildOwnedAttachment1ListLoadStatus
		{
			get;
		}

		IAttachment1List ChildOwnedAttachment1List
		{
			get;
		}

		// Load a single entity object into the collection.
		IAttachment1List LoadChildOwnedAttachment1List(IAttachment1 attachment1);

		// Load collection from repository.
		IAttachment1List LoadChildOwnedAttachment1List();

		void UnloadChildOwnedAttachment1List();

		bool HasChildOwnedAttachment1Objects(bool inMemoryOnly);

		#endregion Attachment1 Relationship

		#region DependentEntity2 Relationship

		LoadStatus ChildOwnedDependentEntity2ListLoadStatus
		{
			get;
		}

		IDependentEntity2List ChildOwnedDependentEntity2List
		{
			get;
		}

		// Load a single entity object into the collection.
		IDependentEntity2List LoadChildOwnedDependentEntity2List(IDependentEntity2 dependentEntity2);

		// Load collection from repository.
		IDependentEntity2List LoadChildOwnedDependentEntity2List();

		void UnloadChildOwnedDependentEntity2List();

		bool HasChildOwnedDependentEntity2Objects(bool inMemoryOnly);

		#endregion DependentEntity2 Relationship

		#endregion // Owned Inbound Relationships

		#region Non-Owned Inbound Relationships

		// This entity has no non-owned inbound relationships.

		#endregion // Non-Owned Inbound Relationships

		#endregion // Inbound Relationships

		// ========================================================================================================================

		#region // Outbound Relationships

		#region Owner Outbound Relationships

		#region IndependentEntity1 Relationship

		bool ParentOwnerIndependentEntity1_DependentEntity1ListPartialLoadAttempted
		{
			get;
		}

		IDependentEntity1List ParentOwnerIndependentEntity1_DependentEntity1List
		{
			get;
		}

		void LoadParentOwnerIndependentEntity1_DependentEntity1List();

		void UnloadParentOwnerIndependentEntity1_DependentEntity1List();

		IIndependentEntity1 ParentOwnerIndependentEntity1EntityObject
		{
			get;
		}

		bool HasParentOwnerIndependentEntity1Object(bool inMemoryOnly);

		#endregion IndependentEntity1 Relationship

		#endregion // Owner Outbound Relationships

		#region Non-Owner Outbound Relationships

		// This entity has no non-owner outbound relationships.

		#endregion // Non-Owner Outbound Relationships

		#endregion // Outbound Relationships

		// ========================================================================================================================

		IDependentEntity1 Copy(bool recurse);

		// ========================================================================================================================

		#region // Outbound Relationships Properties

		#region Owner Outbound Relationships Properties

		#region IndependentEntity1 Relationship

		bool? ParentOwnerIndependentEntity1EntityObject_AttrBool1
		{
			get;
		}

		DateTime? ParentOwnerIndependentEntity1EntityObject_AttrDatetime1
		{
			get;
		}

		int? ParentOwnerIndependentEntity1EntityObject_AttrInteger1
		{
			get;
		}

		string ParentOwnerIndependentEntity1EntityObject_AttrString1
		{
			get;
		}

		string ParentOwnerIndependentEntity1EntityObject_AttrString2
		{
			get;
		}

		string ParentOwnerIndependentEntity1EntityObject_Name
		{
			get;
		}

		string ParentOwnerIndependentEntity1EntityObject_Status
		{
			get;
		}

		#endregion IndependentEntity1 Relationship Properties

		#endregion // Owner Outbound Relationships Properties

		#region Non-Owner Outbound Relationships Properties


		// This entity has no non-owner outbound relationships.

		#endregion // Non-Owner Outbound Relationships Properties

		#endregion // Outbound Relationships Properties

		// ========================================================================================================================
	}

	public partial interface IDependentEntity2 : IEntityObject
	{
		DependentEntity2Identifier? ObjectId
		{
			get;
			set;
		}

		object ObjectId_DBObjectValue
		{
			get;
			set;
		}

		int? DependentEntity2Id
		{
			get;
		}

		object DependentEntity2Id_DBObjectValue
		{
			get;
		}

		bool? AttrBool1
		{
			get;
			set;
		}

		object AttrBool1_DBObjectValue
		{
			get;
			set;
		}

		bool AttrBool1_NoNull
		{
			get;
			set;
		}

		DateTime? AttrDatetime1
		{
			get;
			set;
		}

		object AttrDatetime1_DBObjectValue
		{
			get;
			set;
		}

		DateTime AttrDatetime1_NoNull
		{
			get;
			set;
		}

		int? AttrInteger1
		{
			get;
			set;
		}

		object AttrInteger1_DBObjectValue
		{
			get;
			set;
		}

		int AttrInteger1_NoNull
		{
			get;
			set;
		}

		string AttrString1
		{
			get;
			set;
		}

		object AttrString1_DBObjectValue
		{
			get;
			set;
		}

		string AttrString2
		{
			get;
			set;
		}

		object AttrString2_DBObjectValue
		{
			get;
			set;
		}

		string Name
		{
			get;
			set;
		}

		object Name_DBObjectValue
		{
			get;
			set;
		}

		string Status
		{
			get;
			set;
		}

		object Status_DBObjectValue
		{
			get;
			set;
		}

		DependentEntity1Identifier? ParentOwnerDependentEntity1EntityObjectId
		{
			get;
			set;
		}

		object ParentOwnerDependentEntity1EntityObjectId_DBObjectValue
		{
			get;
			set;
		}

		int? DependentEntity1Id
		{
			get;
		}

		object DependentEntity1Id_DBObjectValue
		{
			get;
		}

		bool SameAs(IDependentEntity2 obj);

		// ========================================================================================================================

		#region Inbound Relationships

		#region Owned Inbound Relationships

		#region RelationshipEntity1 Relationship

		LoadStatus ChildOwnedRelationshipEntity1ListLoadStatus
		{
			get;
		}

		IRelationshipEntity1List ChildOwnedRelationshipEntity1List
		{
			get;
		}

		// Load a single entity object into the collection.
		IRelationshipEntity1List LoadChildOwnedRelationshipEntity1List(IRelationshipEntity1 relationshipEntity1);

		// Load collection from repository.
		IRelationshipEntity1List LoadChildOwnedRelationshipEntity1List();

		void UnloadChildOwnedRelationshipEntity1List();

		bool HasChildOwnedRelationshipEntity1Objects(bool inMemoryOnly);

		#endregion RelationshipEntity1 Relationship

		#endregion // Owned Inbound Relationships

		#region Non-Owned Inbound Relationships

		// This entity has no non-owned inbound relationships.

		#endregion // Non-Owned Inbound Relationships

		#endregion // Inbound Relationships

		// ========================================================================================================================

		#region // Outbound Relationships

		#region Owner Outbound Relationships

		#region DependentEntity1 Relationship

		bool ParentOwnerDependentEntity1_DependentEntity2ListPartialLoadAttempted
		{
			get;
		}

		IDependentEntity2List ParentOwnerDependentEntity1_DependentEntity2List
		{
			get;
		}

		void LoadParentOwnerDependentEntity1_DependentEntity2List();

		void UnloadParentOwnerDependentEntity1_DependentEntity2List();

		IDependentEntity1 ParentOwnerDependentEntity1EntityObject
		{
			get;
		}

		bool HasParentOwnerDependentEntity1Object(bool inMemoryOnly);

		#endregion DependentEntity1 Relationship

		#endregion // Owner Outbound Relationships

		#region Non-Owner Outbound Relationships

		// This entity has no non-owner outbound relationships.

		#endregion // Non-Owner Outbound Relationships

		#endregion // Outbound Relationships

		// ========================================================================================================================

		IDependentEntity2 Copy(bool recurse);

		// ========================================================================================================================

		#region // Outbound Relationships Properties

		#region Owner Outbound Relationships Properties

		#region DependentEntity1 Relationship

		int? ParentOwnerDependentEntity1EntityObject_IndependentEntity1Id
		{
			get;
		}

		bool? ParentOwnerDependentEntity1EntityObject_AttrBool1
		{
			get;
		}

		DateTime? ParentOwnerDependentEntity1EntityObject_AttrDatetime1
		{
			get;
		}

		int? ParentOwnerDependentEntity1EntityObject_AttrInteger1
		{
			get;
		}

		string ParentOwnerDependentEntity1EntityObject_AttrString1
		{
			get;
		}

		string ParentOwnerDependentEntity1EntityObject_AttrString2
		{
			get;
		}

		string ParentOwnerDependentEntity1EntityObject_Name
		{
			get;
		}

		string ParentOwnerDependentEntity1EntityObject_Status
		{
			get;
		}

		#endregion DependentEntity1 Relationship Properties

		#endregion // Owner Outbound Relationships Properties

		#region Non-Owner Outbound Relationships Properties


		// This entity has no non-owner outbound relationships.

		#endregion // Non-Owner Outbound Relationships Properties

		#endregion // Outbound Relationships Properties

		// ========================================================================================================================
	}

	public partial interface IIndependentEntity1 : IEntityObject
	{
		IndependentEntity1Identifier? ObjectId
		{
			get;
			set;
		}

		object ObjectId_DBObjectValue
		{
			get;
			set;
		}

		int? IndependentEntity1Id
		{
			get;
		}

		object IndependentEntity1Id_DBObjectValue
		{
			get;
		}

		bool? AttrBool1
		{
			get;
			set;
		}

		object AttrBool1_DBObjectValue
		{
			get;
			set;
		}

		bool AttrBool1_NoNull
		{
			get;
			set;
		}

		DateTime? AttrDatetime1
		{
			get;
			set;
		}

		object AttrDatetime1_DBObjectValue
		{
			get;
			set;
		}

		DateTime AttrDatetime1_NoNull
		{
			get;
			set;
		}

		int? AttrInteger1
		{
			get;
			set;
		}

		object AttrInteger1_DBObjectValue
		{
			get;
			set;
		}

		int AttrInteger1_NoNull
		{
			get;
			set;
		}

		string AttrString1
		{
			get;
			set;
		}

		object AttrString1_DBObjectValue
		{
			get;
			set;
		}

		string AttrString2
		{
			get;
			set;
		}

		object AttrString2_DBObjectValue
		{
			get;
			set;
		}

		string Name
		{
			get;
			set;
		}

		object Name_DBObjectValue
		{
			get;
			set;
		}

		string Status
		{
			get;
			set;
		}

		object Status_DBObjectValue
		{
			get;
			set;
		}

		bool SameAs(IIndependentEntity1 obj);

		// ========================================================================================================================

		#region Inbound Relationships

		#region Owned Inbound Relationships

		#region DependentEntity1 Relationship

		LoadStatus ChildOwnedDependentEntity1ListLoadStatus
		{
			get;
		}

		IDependentEntity1List ChildOwnedDependentEntity1List
		{
			get;
		}

		// Load a single entity object into the collection.
		IDependentEntity1List LoadChildOwnedDependentEntity1List(IDependentEntity1 dependentEntity1);

		// Load collection from repository.
		IDependentEntity1List LoadChildOwnedDependentEntity1List();

		void UnloadChildOwnedDependentEntity1List();

		bool HasChildOwnedDependentEntity1Objects(bool inMemoryOnly);

		#endregion DependentEntity1 Relationship

		#endregion // Owned Inbound Relationships

		#region Non-Owned Inbound Relationships

		// This entity has no non-owned inbound relationships.

		#endregion // Non-Owned Inbound Relationships

		#endregion // Inbound Relationships

		// ========================================================================================================================

		#region // Outbound Relationships

		#region Owner Outbound Relationships

		// This entity has no owner outbound relationships.

		#endregion // Owner Outbound Relationships

		#region Non-Owner Outbound Relationships

		// This entity has no non-owner outbound relationships.

		#endregion // Non-Owner Outbound Relationships

		#endregion // Outbound Relationships

		// ========================================================================================================================

		IIndependentEntity1 Copy(bool recurse);

		// ========================================================================================================================

		#region // Outbound Relationships Properties

		#region Owner Outbound Relationships Properties

		// This entity has no owner outbound relationships.

		#endregion // Owner Outbound Relationships Properties

		#region Non-Owner Outbound Relationships Properties


		// This entity has no non-owner outbound relationships.

		#endregion // Non-Owner Outbound Relationships Properties

		#endregion // Outbound Relationships Properties

		// ========================================================================================================================
	}

	public partial interface IIndependentEntity2 : IEntityObject
	{
		IndependentEntity2Identifier? ObjectId
		{
			get;
			set;
		}

		object ObjectId_DBObjectValue
		{
			get;
			set;
		}

		int? IndependentEntity2Id
		{
			get;
		}

		object IndependentEntity2Id_DBObjectValue
		{
			get;
		}

		bool? AttrBool1
		{
			get;
			set;
		}

		object AttrBool1_DBObjectValue
		{
			get;
			set;
		}

		bool AttrBool1_NoNull
		{
			get;
			set;
		}

		DateTime? AttrDatetime1
		{
			get;
			set;
		}

		object AttrDatetime1_DBObjectValue
		{
			get;
			set;
		}

		DateTime AttrDatetime1_NoNull
		{
			get;
			set;
		}

		int? AttrInteger1
		{
			get;
			set;
		}

		object AttrInteger1_DBObjectValue
		{
			get;
			set;
		}

		int AttrInteger1_NoNull
		{
			get;
			set;
		}

		string AttrString1
		{
			get;
			set;
		}

		object AttrString1_DBObjectValue
		{
			get;
			set;
		}

		string AttrString2
		{
			get;
			set;
		}

		object AttrString2_DBObjectValue
		{
			get;
			set;
		}

		string Name
		{
			get;
			set;
		}

		object Name_DBObjectValue
		{
			get;
			set;
		}

		string Status
		{
			get;
			set;
		}

		object Status_DBObjectValue
		{
			get;
			set;
		}

		bool SameAs(IIndependentEntity2 obj);

		// ========================================================================================================================

		#region Inbound Relationships

		#region Owned Inbound Relationships

		#region RelationshipEntity1 Relationship

		LoadStatus ChildOwnedRelationshipEntity1ListLoadStatus
		{
			get;
		}

		IRelationshipEntity1List ChildOwnedRelationshipEntity1List
		{
			get;
		}

		// Load a single entity object into the collection.
		IRelationshipEntity1List LoadChildOwnedRelationshipEntity1List(IRelationshipEntity1 relationshipEntity1);

		// Load collection from repository.
		IRelationshipEntity1List LoadChildOwnedRelationshipEntity1List();

		void UnloadChildOwnedRelationshipEntity1List();

		bool HasChildOwnedRelationshipEntity1Objects(bool inMemoryOnly);

		#endregion RelationshipEntity1 Relationship

		#endregion // Owned Inbound Relationships

		#region Non-Owned Inbound Relationships

		// This entity has no non-owned inbound relationships.

		#endregion // Non-Owned Inbound Relationships

		#endregion // Inbound Relationships

		// ========================================================================================================================

		#region // Outbound Relationships

		#region Owner Outbound Relationships

		// This entity has no owner outbound relationships.

		#endregion // Owner Outbound Relationships

		#region Non-Owner Outbound Relationships

		// This entity has no non-owner outbound relationships.

		#endregion // Non-Owner Outbound Relationships

		#endregion // Outbound Relationships

		// ========================================================================================================================

		IIndependentEntity2 Copy(bool recurse);

		// ========================================================================================================================

		#region // Outbound Relationships Properties

		#region Owner Outbound Relationships Properties

		// This entity has no owner outbound relationships.

		#endregion // Owner Outbound Relationships Properties

		#region Non-Owner Outbound Relationships Properties


		// This entity has no non-owner outbound relationships.

		#endregion // Non-Owner Outbound Relationships Properties

		#endregion // Outbound Relationships Properties

		// ========================================================================================================================
	}

	public partial interface IRelationshipEntity1 : IEntityObject
	{
		RelationshipEntity1Identifier? ObjectId
		{
			get;
			set;
		}

		object ObjectId_DBObjectValue
		{
			get;
			set;
		}

		int? RelationshipEntity1Id
		{
			get;
		}

		object RelationshipEntity1Id_DBObjectValue
		{
			get;
		}

		bool? AttrBool1
		{
			get;
			set;
		}

		object AttrBool1_DBObjectValue
		{
			get;
			set;
		}

		bool AttrBool1_NoNull
		{
			get;
			set;
		}

		DateTime? AttrDatetime1
		{
			get;
			set;
		}

		object AttrDatetime1_DBObjectValue
		{
			get;
			set;
		}

		DateTime AttrDatetime1_NoNull
		{
			get;
			set;
		}

		int? AttrInteger1
		{
			get;
			set;
		}

		object AttrInteger1_DBObjectValue
		{
			get;
			set;
		}

		int AttrInteger1_NoNull
		{
			get;
			set;
		}

		string AttrString1
		{
			get;
			set;
		}

		object AttrString1_DBObjectValue
		{
			get;
			set;
		}

		string AttrString2
		{
			get;
			set;
		}

		object AttrString2_DBObjectValue
		{
			get;
			set;
		}

		string Name
		{
			get;
			set;
		}

		object Name_DBObjectValue
		{
			get;
			set;
		}

		string Status
		{
			get;
			set;
		}

		object Status_DBObjectValue
		{
			get;
			set;
		}

		DependentEntity2Identifier? ParentOwnerDependentEntity2EntityObjectId
		{
			get;
			set;
		}

		object ParentOwnerDependentEntity2EntityObjectId_DBObjectValue
		{
			get;
			set;
		}

		int? DependentEntity2Id
		{
			get;
		}

		object DependentEntity2Id_DBObjectValue
		{
			get;
		}

		IndependentEntity2Identifier? ParentOwnerIndependentEntity2EntityObjectId
		{
			get;
			set;
		}

		object ParentOwnerIndependentEntity2EntityObjectId_DBObjectValue
		{
			get;
			set;
		}

		int? IndependentEntity2Id
		{
			get;
		}

		object IndependentEntity2Id_DBObjectValue
		{
			get;
		}

		bool SameAs(IRelationshipEntity1 obj);

		// ========================================================================================================================

		#region Inbound Relationships

		#region Owned Inbound Relationships

		// This entity has no owned inbound relationships.

		#endregion // Owned Inbound Relationships

		#region Non-Owned Inbound Relationships

		// This entity has no non-owned inbound relationships.

		#endregion // Non-Owned Inbound Relationships

		#endregion // Inbound Relationships

		// ========================================================================================================================

		#region // Outbound Relationships

		#region Owner Outbound Relationships

		#region DependentEntity2 Relationship

		bool ParentOwnerDependentEntity2_RelationshipEntity1ListPartialLoadAttempted
		{
			get;
		}

		IRelationshipEntity1List ParentOwnerDependentEntity2_RelationshipEntity1List
		{
			get;
		}

		void LoadParentOwnerDependentEntity2_RelationshipEntity1List();

		void UnloadParentOwnerDependentEntity2_RelationshipEntity1List();

		IDependentEntity2 ParentOwnerDependentEntity2EntityObject
		{
			get;
		}

		bool HasParentOwnerDependentEntity2Object(bool inMemoryOnly);

		#endregion DependentEntity2 Relationship

		#region IndependentEntity2 Relationship

		bool ParentOwnerIndependentEntity2_RelationshipEntity1ListPartialLoadAttempted
		{
			get;
		}

		IRelationshipEntity1List ParentOwnerIndependentEntity2_RelationshipEntity1List
		{
			get;
		}

		void LoadParentOwnerIndependentEntity2_RelationshipEntity1List();

		void UnloadParentOwnerIndependentEntity2_RelationshipEntity1List();

		IIndependentEntity2 ParentOwnerIndependentEntity2EntityObject
		{
			get;
		}

		bool HasParentOwnerIndependentEntity2Object(bool inMemoryOnly);

		#endregion IndependentEntity2 Relationship

		#endregion // Owner Outbound Relationships

		#region Non-Owner Outbound Relationships

		// This entity has no non-owner outbound relationships.

		#endregion // Non-Owner Outbound Relationships

		#endregion // Outbound Relationships

		// ========================================================================================================================

		IRelationshipEntity1 Copy(bool recurse);

		// ========================================================================================================================

		#region // Outbound Relationships Properties

		#region Owner Outbound Relationships Properties

		#region DependentEntity2 Relationship

		int? ParentOwnerDependentEntity2EntityObject_DependentEntity1Id
		{
			get;
		}

		bool? ParentOwnerDependentEntity2EntityObject_AttrBool1
		{
			get;
		}

		DateTime? ParentOwnerDependentEntity2EntityObject_AttrDatetime1
		{
			get;
		}

		int? ParentOwnerDependentEntity2EntityObject_AttrInteger1
		{
			get;
		}

		string ParentOwnerDependentEntity2EntityObject_AttrString1
		{
			get;
		}

		string ParentOwnerDependentEntity2EntityObject_AttrString2
		{
			get;
		}

		string ParentOwnerDependentEntity2EntityObject_Name
		{
			get;
		}

		string ParentOwnerDependentEntity2EntityObject_Status
		{
			get;
		}

		#endregion DependentEntity2 Relationship Properties

		#region IndependentEntity2 Relationship

		bool? ParentOwnerIndependentEntity2EntityObject_AttrBool1
		{
			get;
		}

		DateTime? ParentOwnerIndependentEntity2EntityObject_AttrDatetime1
		{
			get;
		}

		int? ParentOwnerIndependentEntity2EntityObject_AttrInteger1
		{
			get;
		}

		string ParentOwnerIndependentEntity2EntityObject_AttrString1
		{
			get;
		}

		string ParentOwnerIndependentEntity2EntityObject_AttrString2
		{
			get;
		}

		string ParentOwnerIndependentEntity2EntityObject_Name
		{
			get;
		}

		string ParentOwnerIndependentEntity2EntityObject_Status
		{
			get;
		}

		#endregion IndependentEntity2 Relationship Properties

		#endregion // Owner Outbound Relationships Properties

		#region Non-Owner Outbound Relationships Properties


		// This entity has no non-owner outbound relationships.

		#endregion // Non-Owner Outbound Relationships Properties

		#endregion // Outbound Relationships Properties

		// ========================================================================================================================
	}
}
