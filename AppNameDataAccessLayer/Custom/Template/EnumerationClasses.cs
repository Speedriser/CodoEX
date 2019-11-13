using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustName.AppName.DAL
{

	public enum CollectionName : int
	{
		None = 0,
		DependentEntity1_ChildOwnedAttachment1List = 1,
		DependentEntity1_ChildOwnedDependentEntity2List = 2,
		DependentEntity2_ChildOwnedRelationshipEntity1List = 3,
		IndependentEntity1_ChildOwnedDependentEntity1List = 4,
		IndependentEntity2_ChildOwnedRelationshipEntity1List = 5
	}

	public enum CollisionType : int
	{
		None = 0,
		Update = 1,
		Delete = 2
	}

	public enum EntityClass : int
	{
		None = 0,
		Attachment1 = 1,
		DependentEntity1 = 2,
		DependentEntity2 = 3,
		IndependentEntity1 = 4,
		IndependentEntity2 = 5,
		RelationshipEntity1 = 6
	}

	public enum EntityType : int
	{
		None = 0,
		Independent = 1,
		SemiIndependent = 2,
		Dependent = 3,
		Relationship = 4
	}

	public enum LoadStatus : int
	{
		None = 0,
		Full = 1,
		Partial = 2,
		NotLoaded = 3
	}

	// Possible statuses with respect to the repository.
	public enum ObjectStatus : int
	{
		None = 0,
		New = 1,
		Existing = 2,
		Deleted = 3,
		Outdated = 4
	}

	public enum OperandType : int
	{
		None = 0,
		PropertyName = 1,
		Literal = 2
	}

	public enum RepositoryUpdateOperation : int
	{
		None = 0,
		Insert = 1,
		Update = 2,
		Delete = 3
	}

	public enum Attachment1BasePropertyName : int
	{
		None = 0,
		Attachment1Id = 1,
		DependentEntity1Id = 2,
		AttachmentNotes = 3,
		AttachmentType = 4,
		AttrBool1 = 5,
		AttrDatetime1 = 6,
		AttrInteger1 = 7,
		AttrString1 = 8,
		AttrString2 = 9,
		FileAttachment = 10,
		Name = 11,
		Status = 12,
		CreateTimestamp = 13,
		CreateUser = 14,
		LastUpdateTimestamp = 15,
		LastUpdateUser = 16,
		UpdateId = 17
	}

	public enum DependentEntity1BasePropertyName : int
	{
		None = 0,
		DependentEntity1Id = 1,
		IndependentEntity1Id = 2,
		AttrBool1 = 3,
		AttrDatetime1 = 4,
		AttrInteger1 = 5,
		AttrString1 = 6,
		AttrString2 = 7,
		Name = 8,
		Status = 9,
		CreateTimestamp = 10,
		CreateUser = 11,
		LastUpdateTimestamp = 12,
		LastUpdateUser = 13,
		UpdateId = 14
	}

	public enum DependentEntity2BasePropertyName : int
	{
		None = 0,
		DependentEntity2Id = 1,
		DependentEntity1Id = 2,
		AttrBool1 = 3,
		AttrDatetime1 = 4,
		AttrInteger1 = 5,
		AttrString1 = 6,
		AttrString2 = 7,
		Name = 8,
		Status = 9,
		CreateTimestamp = 10,
		CreateUser = 11,
		LastUpdateTimestamp = 12,
		LastUpdateUser = 13,
		UpdateId = 14
	}

	public enum IndependentEntity1BasePropertyName : int
	{
		None = 0,
		IndependentEntity1Id = 1,
		AttrBool1 = 2,
		AttrDatetime1 = 3,
		AttrInteger1 = 4,
		AttrString1 = 5,
		AttrString2 = 6,
		Name = 7,
		Status = 8,
		CreateTimestamp = 9,
		CreateUser = 10,
		LastUpdateTimestamp = 11,
		LastUpdateUser = 12,
		UpdateId = 13
	}

	public enum IndependentEntity2BasePropertyName : int
	{
		None = 0,
		IndependentEntity2Id = 1,
		AttrBool1 = 2,
		AttrDatetime1 = 3,
		AttrInteger1 = 4,
		AttrString1 = 5,
		AttrString2 = 6,
		Name = 7,
		Status = 8,
		CreateTimestamp = 9,
		CreateUser = 10,
		LastUpdateTimestamp = 11,
		LastUpdateUser = 12,
		UpdateId = 13
	}

	public enum RelationshipEntity1BasePropertyName : int
	{
		None = 0,
		RelationshipEntity1Id = 1,
		DependentEntity2Id = 2,
		IndependentEntity2Id = 3,
		AttrBool1 = 4,
		AttrDatetime1 = 5,
		AttrInteger1 = 6,
		AttrString1 = 7,
		AttrString2 = 8,
		Name = 9,
		Status = 10,
		CreateTimestamp = 11,
		CreateUser = 12,
		LastUpdateTimestamp = 13,
		LastUpdateUser = 14,
		UpdateId = 15
	}

	public enum Attachment1PropertyName : int
	{
		None = 0,
		Attachment1Id = 1,
		DependentEntity1Id = 2,
		AttachmentNotes = 3,
		AttachmentType = 4,
		AttrBool1 = 5,
		AttrDatetime1 = 6,
		AttrInteger1 = 7,
		AttrString1 = 8,
		AttrString2 = 9,
		FileAttachment = 10,
		Name = 11,
		Status = 12,
		CreateTimestamp = 13,
		CreateUser = 14,
		LastUpdateTimestamp = 15,
		LastUpdateUser = 16,
		UpdateId = 17,
		ObjectId = 18,
		ParentOwnerDependentEntity1EntityObjectId = 19
	}

	public enum DependentEntity1PropertyName : int
	{
		None = 0,
		DependentEntity1Id = 1,
		IndependentEntity1Id = 2,
		AttrBool1 = 3,
		AttrDatetime1 = 4,
		AttrInteger1 = 5,
		AttrString1 = 6,
		AttrString2 = 7,
		Name = 8,
		Status = 9,
		CreateTimestamp = 10,
		CreateUser = 11,
		LastUpdateTimestamp = 12,
		LastUpdateUser = 13,
		UpdateId = 14,
		ObjectId = 15,
		ParentOwnerIndependentEntity1EntityObjectId = 16
	}

	public enum DependentEntity2PropertyName : int
	{
		None = 0,
		DependentEntity2Id = 1,
		DependentEntity1Id = 2,
		AttrBool1 = 3,
		AttrDatetime1 = 4,
		AttrInteger1 = 5,
		AttrString1 = 6,
		AttrString2 = 7,
		Name = 8,
		Status = 9,
		CreateTimestamp = 10,
		CreateUser = 11,
		LastUpdateTimestamp = 12,
		LastUpdateUser = 13,
		UpdateId = 14,
		ObjectId = 15,
		ParentOwnerDependentEntity1EntityObjectId = 16
	}

	public enum IndependentEntity1PropertyName : int
	{
		None = 0,
		IndependentEntity1Id = 1,
		AttrBool1 = 2,
		AttrDatetime1 = 3,
		AttrInteger1 = 4,
		AttrString1 = 5,
		AttrString2 = 6,
		Name = 7,
		Status = 8,
		CreateTimestamp = 9,
		CreateUser = 10,
		LastUpdateTimestamp = 11,
		LastUpdateUser = 12,
		UpdateId = 13,
		ObjectId = 14
	}

	public enum IndependentEntity2PropertyName : int
	{
		None = 0,
		IndependentEntity2Id = 1,
		AttrBool1 = 2,
		AttrDatetime1 = 3,
		AttrInteger1 = 4,
		AttrString1 = 5,
		AttrString2 = 6,
		Name = 7,
		Status = 8,
		CreateTimestamp = 9,
		CreateUser = 10,
		LastUpdateTimestamp = 11,
		LastUpdateUser = 12,
		UpdateId = 13,
		ObjectId = 14
	}

	public enum RelationshipEntity1PropertyName : int
	{
		None = 0,
		RelationshipEntity1Id = 1,
		DependentEntity2Id = 2,
		IndependentEntity2Id = 3,
		AttrBool1 = 4,
		AttrDatetime1 = 5,
		AttrInteger1 = 6,
		AttrString1 = 7,
		AttrString2 = 8,
		Name = 9,
		Status = 10,
		CreateTimestamp = 11,
		CreateUser = 12,
		LastUpdateTimestamp = 13,
		LastUpdateUser = 14,
		UpdateId = 15,
		ObjectId = 16,
		ParentOwnerDependentEntity2EntityObjectId = 17,
		ParentOwnerIndependentEntity2EntityObjectId = 18
	}
}
