using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CustName.AppName.DAL
{
	// < search_condition > ::=
	//     { [ NOT ] <predicate> | ( <search_condition> ) }
	//     [ { AND | OR } [ NOT ] { <predicate> | ( <search_condition> ) } ]
	// [ ,...n ]
	// <predicate> ::=
	//     { expression { = | < > | ! = | > | > = | ! > | < | < = | ! < } expression
	//     | string_expression [ NOT ] LIKE string_expression
	//   [ ESCAPE 'escape_character' ]
	//     | expression [ NOT ] BETWEEN expression AND expression
	//     | expression IS [ NOT ] NULL
	//     | CONTAINS
	//     ( { column | * } , '< contains_search_condition >' )
	//     | FREETEXT ( { column | * } , 'freetext_string' )
	//     | expression [ NOT ] IN ( subquery | expression [ ,...n ] )
	//     | expression { = | < > | ! = | > | > = | ! > | < | < = | ! < }
	//   { ALL | SOME | ANY} ( subquery )
	//     | EXISTS ( subquery )     }
	public abstract class BaseSearchCondition
	{
		public const string ParamPlaceholderString = "@param_";

		private StringBuilder conditionStringBuilder = new StringBuilder();
		internal List<QueryConstant> ConstantList = new List<QueryConstant>();

		public virtual SearchCondition Append(string value)
		{
			this.conditionStringBuilder.Append(value);
			return (SearchCondition)this;
		}

		public virtual SearchCondition AppendOperator(SearchConditionOperatorConstant conditionOperator)
		{
			if (conditionOperator == SearchConditionOperator.And)
			{
				Append(" ");
				Append(SearchConditionOperator.And.Value);
				Append(" ");
			}
			else if (conditionOperator == SearchConditionOperator.Not)
			{
				Append(SearchConditionOperator.Not.Value);
				Append(" ");
			}
			else if (conditionOperator == SearchConditionOperator.Or)
			{
				Append(" ");
				Append(SearchConditionOperator.Or.Value);
				Append(" ");
			}
			return (SearchCondition)this;
		}

		public virtual SearchCondition AppendOperator(SearchConditionExpressionOperatorConstant expressionOperator)
		{
			Append(" ");
			Append(expressionOperator.Value);
			Append(" ");
			return (SearchCondition)this;
		}

		public virtual SearchCondition AppendSearchCondition(SearchCondition sc)
		{
			if (sc != null)
			{
				Append("(" + sc.ToString() + ")");
				this.ConstantList.AddRange(sc.ConstantList);
			}
			return (SearchCondition)this;
		}

		public virtual SearchCondition AppendSearchCondition(Attachment1PropertyName propertyName, SearchConditionExpressionOperatorConstant expressionOperator, object value)
		{
			if (propertyName == Attachment1PropertyName.ObjectId)
			{
				Attachment1Identifier identifier = (Attachment1Identifier)value;
				AppendPropertyName(Attachment1BasePropertyName.Attachment1Id);
				AppendOperator(expressionOperator);
				AppendPropertyValue(Attachment1BasePropertyName.Attachment1Id, identifier.Attachment1Id);
			}
			else if (propertyName == Attachment1PropertyName.ParentOwnerDependentEntity1EntityObjectId)
			{
				DependentEntity1Identifier identifier = (DependentEntity1Identifier)value;
				AppendPropertyName(Attachment1BasePropertyName.DependentEntity1Id);
				AppendOperator(expressionOperator);
				AppendPropertyValue(Attachment1BasePropertyName.DependentEntity1Id, identifier.DependentEntity1Id);
			}
			else if (propertyName == Attachment1PropertyName.Attachment1Id)
			{
				AppendPropertyName(Attachment1BasePropertyName.Attachment1Id);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(Attachment1BasePropertyName.Attachment1Id, value);
			}
			else if (propertyName == Attachment1PropertyName.DependentEntity1Id)
			{
				AppendPropertyName(Attachment1BasePropertyName.DependentEntity1Id);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(Attachment1BasePropertyName.DependentEntity1Id, value);
			}
			else if (propertyName == Attachment1PropertyName.AttachmentNotes)
			{
				AppendPropertyName(Attachment1BasePropertyName.AttachmentNotes);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(Attachment1BasePropertyName.AttachmentNotes, value);
			}
			else if (propertyName == Attachment1PropertyName.AttachmentType)
			{
				AppendPropertyName(Attachment1BasePropertyName.AttachmentType);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(Attachment1BasePropertyName.AttachmentType, value);
			}
			else if (propertyName == Attachment1PropertyName.AttrBool1)
			{
				AppendPropertyName(Attachment1BasePropertyName.AttrBool1);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(Attachment1BasePropertyName.AttrBool1, value);
			}
			else if (propertyName == Attachment1PropertyName.AttrDatetime1)
			{
				AppendPropertyName(Attachment1BasePropertyName.AttrDatetime1);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(Attachment1BasePropertyName.AttrDatetime1, value);
			}
			else if (propertyName == Attachment1PropertyName.AttrInteger1)
			{
				AppendPropertyName(Attachment1BasePropertyName.AttrInteger1);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(Attachment1BasePropertyName.AttrInteger1, value);
			}
			else if (propertyName == Attachment1PropertyName.AttrString1)
			{
				AppendPropertyName(Attachment1BasePropertyName.AttrString1);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(Attachment1BasePropertyName.AttrString1, value);
			}
			else if (propertyName == Attachment1PropertyName.AttrString2)
			{
				AppendPropertyName(Attachment1BasePropertyName.AttrString2);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(Attachment1BasePropertyName.AttrString2, value);
			}
			else if (propertyName == Attachment1PropertyName.FileAttachment)
			{
				AppendPropertyName(Attachment1BasePropertyName.FileAttachment);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(Attachment1BasePropertyName.FileAttachment, value);
			}
			else if (propertyName == Attachment1PropertyName.Name)
			{
				AppendPropertyName(Attachment1BasePropertyName.Name);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(Attachment1BasePropertyName.Name, value);
			}
			else if (propertyName == Attachment1PropertyName.Status)
			{
				AppendPropertyName(Attachment1BasePropertyName.Status);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(Attachment1BasePropertyName.Status, value);
			}
			else if (propertyName == Attachment1PropertyName.CreateTimestamp)
			{
				AppendPropertyName(Attachment1BasePropertyName.CreateTimestamp);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(Attachment1BasePropertyName.CreateTimestamp, value);
			}
			else if (propertyName == Attachment1PropertyName.CreateUser)
			{
				AppendPropertyName(Attachment1BasePropertyName.CreateUser);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(Attachment1BasePropertyName.CreateUser, value);
			}
			else if (propertyName == Attachment1PropertyName.LastUpdateTimestamp)
			{
				AppendPropertyName(Attachment1BasePropertyName.LastUpdateTimestamp);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(Attachment1BasePropertyName.LastUpdateTimestamp, value);
			}
			else if (propertyName == Attachment1PropertyName.UpdateId)
			{
				AppendPropertyName(Attachment1BasePropertyName.UpdateId);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(Attachment1BasePropertyName.UpdateId, value);
			}
			else if (propertyName == Attachment1PropertyName.LastUpdateUser)
			{
				AppendPropertyName(Attachment1BasePropertyName.LastUpdateUser);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(Attachment1BasePropertyName.LastUpdateUser, value);
			}
			return (SearchCondition)this;
		}

		public virtual SearchCondition AppendSearchCondition(DependentEntity1PropertyName propertyName, SearchConditionExpressionOperatorConstant expressionOperator, object value)
		{
			if (propertyName == DependentEntity1PropertyName.ObjectId)
			{
				DependentEntity1Identifier identifier = (DependentEntity1Identifier)value;
				AppendPropertyName(DependentEntity1BasePropertyName.DependentEntity1Id);
				AppendOperator(expressionOperator);
				AppendPropertyValue(DependentEntity1BasePropertyName.DependentEntity1Id, identifier.DependentEntity1Id);
			}
			else if (propertyName == DependentEntity1PropertyName.ParentOwnerIndependentEntity1EntityObjectId)
			{
				IndependentEntity1Identifier identifier = (IndependentEntity1Identifier)value;
				AppendPropertyName(DependentEntity1BasePropertyName.IndependentEntity1Id);
				AppendOperator(expressionOperator);
				AppendPropertyValue(DependentEntity1BasePropertyName.IndependentEntity1Id, identifier.IndependentEntity1Id);
			}
			else if (propertyName == DependentEntity1PropertyName.DependentEntity1Id)
			{
				AppendPropertyName(DependentEntity1BasePropertyName.DependentEntity1Id);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(DependentEntity1BasePropertyName.DependentEntity1Id, value);
			}
			else if (propertyName == DependentEntity1PropertyName.IndependentEntity1Id)
			{
				AppendPropertyName(DependentEntity1BasePropertyName.IndependentEntity1Id);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(DependentEntity1BasePropertyName.IndependentEntity1Id, value);
			}
			else if (propertyName == DependentEntity1PropertyName.AttrBool1)
			{
				AppendPropertyName(DependentEntity1BasePropertyName.AttrBool1);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(DependentEntity1BasePropertyName.AttrBool1, value);
			}
			else if (propertyName == DependentEntity1PropertyName.AttrDatetime1)
			{
				AppendPropertyName(DependentEntity1BasePropertyName.AttrDatetime1);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(DependentEntity1BasePropertyName.AttrDatetime1, value);
			}
			else if (propertyName == DependentEntity1PropertyName.AttrInteger1)
			{
				AppendPropertyName(DependentEntity1BasePropertyName.AttrInteger1);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(DependentEntity1BasePropertyName.AttrInteger1, value);
			}
			else if (propertyName == DependentEntity1PropertyName.AttrString1)
			{
				AppendPropertyName(DependentEntity1BasePropertyName.AttrString1);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(DependentEntity1BasePropertyName.AttrString1, value);
			}
			else if (propertyName == DependentEntity1PropertyName.AttrString2)
			{
				AppendPropertyName(DependentEntity1BasePropertyName.AttrString2);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(DependentEntity1BasePropertyName.AttrString2, value);
			}
			else if (propertyName == DependentEntity1PropertyName.Name)
			{
				AppendPropertyName(DependentEntity1BasePropertyName.Name);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(DependentEntity1BasePropertyName.Name, value);
			}
			else if (propertyName == DependentEntity1PropertyName.Status)
			{
				AppendPropertyName(DependentEntity1BasePropertyName.Status);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(DependentEntity1BasePropertyName.Status, value);
			}
			else if (propertyName == DependentEntity1PropertyName.CreateTimestamp)
			{
				AppendPropertyName(DependentEntity1BasePropertyName.CreateTimestamp);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(DependentEntity1BasePropertyName.CreateTimestamp, value);
			}
			else if (propertyName == DependentEntity1PropertyName.CreateUser)
			{
				AppendPropertyName(DependentEntity1BasePropertyName.CreateUser);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(DependentEntity1BasePropertyName.CreateUser, value);
			}
			else if (propertyName == DependentEntity1PropertyName.LastUpdateTimestamp)
			{
				AppendPropertyName(DependentEntity1BasePropertyName.LastUpdateTimestamp);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(DependentEntity1BasePropertyName.LastUpdateTimestamp, value);
			}
			else if (propertyName == DependentEntity1PropertyName.UpdateId)
			{
				AppendPropertyName(DependentEntity1BasePropertyName.UpdateId);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(DependentEntity1BasePropertyName.UpdateId, value);
			}
			else if (propertyName == DependentEntity1PropertyName.LastUpdateUser)
			{
				AppendPropertyName(DependentEntity1BasePropertyName.LastUpdateUser);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(DependentEntity1BasePropertyName.LastUpdateUser, value);
			}
			return (SearchCondition)this;
		}

		public virtual SearchCondition AppendSearchCondition(DependentEntity2PropertyName propertyName, SearchConditionExpressionOperatorConstant expressionOperator, object value)
		{
			if (propertyName == DependentEntity2PropertyName.ObjectId)
			{
				DependentEntity2Identifier identifier = (DependentEntity2Identifier)value;
				AppendPropertyName(DependentEntity2BasePropertyName.DependentEntity2Id);
				AppendOperator(expressionOperator);
				AppendPropertyValue(DependentEntity2BasePropertyName.DependentEntity2Id, identifier.DependentEntity2Id);
			}
			else if (propertyName == DependentEntity2PropertyName.ParentOwnerDependentEntity1EntityObjectId)
			{
				DependentEntity1Identifier identifier = (DependentEntity1Identifier)value;
				AppendPropertyName(DependentEntity2BasePropertyName.DependentEntity1Id);
				AppendOperator(expressionOperator);
				AppendPropertyValue(DependentEntity2BasePropertyName.DependentEntity1Id, identifier.DependentEntity1Id);
			}
			else if (propertyName == DependentEntity2PropertyName.DependentEntity2Id)
			{
				AppendPropertyName(DependentEntity2BasePropertyName.DependentEntity2Id);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(DependentEntity2BasePropertyName.DependentEntity2Id, value);
			}
			else if (propertyName == DependentEntity2PropertyName.DependentEntity1Id)
			{
				AppendPropertyName(DependentEntity2BasePropertyName.DependentEntity1Id);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(DependentEntity2BasePropertyName.DependentEntity1Id, value);
			}
			else if (propertyName == DependentEntity2PropertyName.AttrBool1)
			{
				AppendPropertyName(DependentEntity2BasePropertyName.AttrBool1);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(DependentEntity2BasePropertyName.AttrBool1, value);
			}
			else if (propertyName == DependentEntity2PropertyName.AttrDatetime1)
			{
				AppendPropertyName(DependentEntity2BasePropertyName.AttrDatetime1);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(DependentEntity2BasePropertyName.AttrDatetime1, value);
			}
			else if (propertyName == DependentEntity2PropertyName.AttrInteger1)
			{
				AppendPropertyName(DependentEntity2BasePropertyName.AttrInteger1);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(DependentEntity2BasePropertyName.AttrInteger1, value);
			}
			else if (propertyName == DependentEntity2PropertyName.AttrString1)
			{
				AppendPropertyName(DependentEntity2BasePropertyName.AttrString1);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(DependentEntity2BasePropertyName.AttrString1, value);
			}
			else if (propertyName == DependentEntity2PropertyName.AttrString2)
			{
				AppendPropertyName(DependentEntity2BasePropertyName.AttrString2);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(DependentEntity2BasePropertyName.AttrString2, value);
			}
			else if (propertyName == DependentEntity2PropertyName.Name)
			{
				AppendPropertyName(DependentEntity2BasePropertyName.Name);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(DependentEntity2BasePropertyName.Name, value);
			}
			else if (propertyName == DependentEntity2PropertyName.Status)
			{
				AppendPropertyName(DependentEntity2BasePropertyName.Status);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(DependentEntity2BasePropertyName.Status, value);
			}
			else if (propertyName == DependentEntity2PropertyName.CreateTimestamp)
			{
				AppendPropertyName(DependentEntity2BasePropertyName.CreateTimestamp);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(DependentEntity2BasePropertyName.CreateTimestamp, value);
			}
			else if (propertyName == DependentEntity2PropertyName.CreateUser)
			{
				AppendPropertyName(DependentEntity2BasePropertyName.CreateUser);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(DependentEntity2BasePropertyName.CreateUser, value);
			}
			else if (propertyName == DependentEntity2PropertyName.LastUpdateTimestamp)
			{
				AppendPropertyName(DependentEntity2BasePropertyName.LastUpdateTimestamp);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(DependentEntity2BasePropertyName.LastUpdateTimestamp, value);
			}
			else if (propertyName == DependentEntity2PropertyName.UpdateId)
			{
				AppendPropertyName(DependentEntity2BasePropertyName.UpdateId);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(DependentEntity2BasePropertyName.UpdateId, value);
			}
			else if (propertyName == DependentEntity2PropertyName.LastUpdateUser)
			{
				AppendPropertyName(DependentEntity2BasePropertyName.LastUpdateUser);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(DependentEntity2BasePropertyName.LastUpdateUser, value);
			}
			return (SearchCondition)this;
		}

		public virtual SearchCondition AppendSearchCondition(IndependentEntity1PropertyName propertyName, SearchConditionExpressionOperatorConstant expressionOperator, object value)
		{
			if (propertyName == IndependentEntity1PropertyName.ObjectId)
			{
				IndependentEntity1Identifier identifier = (IndependentEntity1Identifier)value;
				AppendPropertyName(IndependentEntity1BasePropertyName.IndependentEntity1Id);
				AppendOperator(expressionOperator);
				AppendPropertyValue(IndependentEntity1BasePropertyName.IndependentEntity1Id, identifier.IndependentEntity1Id);
			}
			else if (propertyName == IndependentEntity1PropertyName.IndependentEntity1Id)
			{
				AppendPropertyName(IndependentEntity1BasePropertyName.IndependentEntity1Id);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(IndependentEntity1BasePropertyName.IndependentEntity1Id, value);
			}
			else if (propertyName == IndependentEntity1PropertyName.AttrBool1)
			{
				AppendPropertyName(IndependentEntity1BasePropertyName.AttrBool1);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(IndependentEntity1BasePropertyName.AttrBool1, value);
			}
			else if (propertyName == IndependentEntity1PropertyName.AttrDatetime1)
			{
				AppendPropertyName(IndependentEntity1BasePropertyName.AttrDatetime1);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(IndependentEntity1BasePropertyName.AttrDatetime1, value);
			}
			else if (propertyName == IndependentEntity1PropertyName.AttrInteger1)
			{
				AppendPropertyName(IndependentEntity1BasePropertyName.AttrInteger1);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(IndependentEntity1BasePropertyName.AttrInteger1, value);
			}
			else if (propertyName == IndependentEntity1PropertyName.AttrString1)
			{
				AppendPropertyName(IndependentEntity1BasePropertyName.AttrString1);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(IndependentEntity1BasePropertyName.AttrString1, value);
			}
			else if (propertyName == IndependentEntity1PropertyName.AttrString2)
			{
				AppendPropertyName(IndependentEntity1BasePropertyName.AttrString2);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(IndependentEntity1BasePropertyName.AttrString2, value);
			}
			else if (propertyName == IndependentEntity1PropertyName.Name)
			{
				AppendPropertyName(IndependentEntity1BasePropertyName.Name);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(IndependentEntity1BasePropertyName.Name, value);
			}
			else if (propertyName == IndependentEntity1PropertyName.Status)
			{
				AppendPropertyName(IndependentEntity1BasePropertyName.Status);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(IndependentEntity1BasePropertyName.Status, value);
			}
			else if (propertyName == IndependentEntity1PropertyName.CreateTimestamp)
			{
				AppendPropertyName(IndependentEntity1BasePropertyName.CreateTimestamp);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(IndependentEntity1BasePropertyName.CreateTimestamp, value);
			}
			else if (propertyName == IndependentEntity1PropertyName.CreateUser)
			{
				AppendPropertyName(IndependentEntity1BasePropertyName.CreateUser);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(IndependentEntity1BasePropertyName.CreateUser, value);
			}
			else if (propertyName == IndependentEntity1PropertyName.LastUpdateTimestamp)
			{
				AppendPropertyName(IndependentEntity1BasePropertyName.LastUpdateTimestamp);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(IndependentEntity1BasePropertyName.LastUpdateTimestamp, value);
			}
			else if (propertyName == IndependentEntity1PropertyName.UpdateId)
			{
				AppendPropertyName(IndependentEntity1BasePropertyName.UpdateId);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(IndependentEntity1BasePropertyName.UpdateId, value);
			}
			else if (propertyName == IndependentEntity1PropertyName.LastUpdateUser)
			{
				AppendPropertyName(IndependentEntity1BasePropertyName.LastUpdateUser);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(IndependentEntity1BasePropertyName.LastUpdateUser, value);
			}
			return (SearchCondition)this;
		}

		public virtual SearchCondition AppendSearchCondition(IndependentEntity2PropertyName propertyName, SearchConditionExpressionOperatorConstant expressionOperator, object value)
		{
			if (propertyName == IndependentEntity2PropertyName.ObjectId)
			{
				IndependentEntity2Identifier identifier = (IndependentEntity2Identifier)value;
				AppendPropertyName(IndependentEntity2BasePropertyName.IndependentEntity2Id);
				AppendOperator(expressionOperator);
				AppendPropertyValue(IndependentEntity2BasePropertyName.IndependentEntity2Id, identifier.IndependentEntity2Id);
			}
			else if (propertyName == IndependentEntity2PropertyName.IndependentEntity2Id)
			{
				AppendPropertyName(IndependentEntity2BasePropertyName.IndependentEntity2Id);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(IndependentEntity2BasePropertyName.IndependentEntity2Id, value);
			}
			else if (propertyName == IndependentEntity2PropertyName.AttrBool1)
			{
				AppendPropertyName(IndependentEntity2BasePropertyName.AttrBool1);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(IndependentEntity2BasePropertyName.AttrBool1, value);
			}
			else if (propertyName == IndependentEntity2PropertyName.AttrDatetime1)
			{
				AppendPropertyName(IndependentEntity2BasePropertyName.AttrDatetime1);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(IndependentEntity2BasePropertyName.AttrDatetime1, value);
			}
			else if (propertyName == IndependentEntity2PropertyName.AttrInteger1)
			{
				AppendPropertyName(IndependentEntity2BasePropertyName.AttrInteger1);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(IndependentEntity2BasePropertyName.AttrInteger1, value);
			}
			else if (propertyName == IndependentEntity2PropertyName.AttrString1)
			{
				AppendPropertyName(IndependentEntity2BasePropertyName.AttrString1);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(IndependentEntity2BasePropertyName.AttrString1, value);
			}
			else if (propertyName == IndependentEntity2PropertyName.AttrString2)
			{
				AppendPropertyName(IndependentEntity2BasePropertyName.AttrString2);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(IndependentEntity2BasePropertyName.AttrString2, value);
			}
			else if (propertyName == IndependentEntity2PropertyName.Name)
			{
				AppendPropertyName(IndependentEntity2BasePropertyName.Name);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(IndependentEntity2BasePropertyName.Name, value);
			}
			else if (propertyName == IndependentEntity2PropertyName.Status)
			{
				AppendPropertyName(IndependentEntity2BasePropertyName.Status);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(IndependentEntity2BasePropertyName.Status, value);
			}
			else if (propertyName == IndependentEntity2PropertyName.CreateTimestamp)
			{
				AppendPropertyName(IndependentEntity2BasePropertyName.CreateTimestamp);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(IndependentEntity2BasePropertyName.CreateTimestamp, value);
			}
			else if (propertyName == IndependentEntity2PropertyName.CreateUser)
			{
				AppendPropertyName(IndependentEntity2BasePropertyName.CreateUser);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(IndependentEntity2BasePropertyName.CreateUser, value);
			}
			else if (propertyName == IndependentEntity2PropertyName.LastUpdateTimestamp)
			{
				AppendPropertyName(IndependentEntity2BasePropertyName.LastUpdateTimestamp);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(IndependentEntity2BasePropertyName.LastUpdateTimestamp, value);
			}
			else if (propertyName == IndependentEntity2PropertyName.UpdateId)
			{
				AppendPropertyName(IndependentEntity2BasePropertyName.UpdateId);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(IndependentEntity2BasePropertyName.UpdateId, value);
			}
			else if (propertyName == IndependentEntity2PropertyName.LastUpdateUser)
			{
				AppendPropertyName(IndependentEntity2BasePropertyName.LastUpdateUser);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(IndependentEntity2BasePropertyName.LastUpdateUser, value);
			}
			return (SearchCondition)this;
		}

		public virtual SearchCondition AppendSearchCondition(RelationshipEntity1PropertyName propertyName, SearchConditionExpressionOperatorConstant expressionOperator, object value)
		{
			if (propertyName == RelationshipEntity1PropertyName.ObjectId)
			{
				RelationshipEntity1Identifier identifier = (RelationshipEntity1Identifier)value;
				AppendPropertyName(RelationshipEntity1BasePropertyName.RelationshipEntity1Id);
				AppendOperator(expressionOperator);
				AppendPropertyValue(RelationshipEntity1BasePropertyName.RelationshipEntity1Id, identifier.RelationshipEntity1Id);
			}
			else if (propertyName == RelationshipEntity1PropertyName.ParentOwnerDependentEntity2EntityObjectId)
			{
				DependentEntity2Identifier identifier = (DependentEntity2Identifier)value;
				AppendPropertyName(RelationshipEntity1BasePropertyName.DependentEntity2Id);
				AppendOperator(expressionOperator);
				AppendPropertyValue(RelationshipEntity1BasePropertyName.DependentEntity2Id, identifier.DependentEntity2Id);
			}
			else if (propertyName == RelationshipEntity1PropertyName.ParentOwnerIndependentEntity2EntityObjectId)
			{
				IndependentEntity2Identifier identifier = (IndependentEntity2Identifier)value;
				AppendPropertyName(RelationshipEntity1BasePropertyName.IndependentEntity2Id);
				AppendOperator(expressionOperator);
				AppendPropertyValue(RelationshipEntity1BasePropertyName.IndependentEntity2Id, identifier.IndependentEntity2Id);
			}
			else if (propertyName == RelationshipEntity1PropertyName.RelationshipEntity1Id)
			{
				AppendPropertyName(RelationshipEntity1BasePropertyName.RelationshipEntity1Id);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(RelationshipEntity1BasePropertyName.RelationshipEntity1Id, value);
			}
			else if (propertyName == RelationshipEntity1PropertyName.DependentEntity2Id)
			{
				AppendPropertyName(RelationshipEntity1BasePropertyName.DependentEntity2Id);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(RelationshipEntity1BasePropertyName.DependentEntity2Id, value);
			}
			else if (propertyName == RelationshipEntity1PropertyName.IndependentEntity2Id)
			{
				AppendPropertyName(RelationshipEntity1BasePropertyName.IndependentEntity2Id);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(RelationshipEntity1BasePropertyName.IndependentEntity2Id, value);
			}
			else if (propertyName == RelationshipEntity1PropertyName.AttrBool1)
			{
				AppendPropertyName(RelationshipEntity1BasePropertyName.AttrBool1);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(RelationshipEntity1BasePropertyName.AttrBool1, value);
			}
			else if (propertyName == RelationshipEntity1PropertyName.AttrDatetime1)
			{
				AppendPropertyName(RelationshipEntity1BasePropertyName.AttrDatetime1);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(RelationshipEntity1BasePropertyName.AttrDatetime1, value);
			}
			else if (propertyName == RelationshipEntity1PropertyName.AttrInteger1)
			{
				AppendPropertyName(RelationshipEntity1BasePropertyName.AttrInteger1);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(RelationshipEntity1BasePropertyName.AttrInteger1, value);
			}
			else if (propertyName == RelationshipEntity1PropertyName.AttrString1)
			{
				AppendPropertyName(RelationshipEntity1BasePropertyName.AttrString1);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(RelationshipEntity1BasePropertyName.AttrString1, value);
			}
			else if (propertyName == RelationshipEntity1PropertyName.AttrString2)
			{
				AppendPropertyName(RelationshipEntity1BasePropertyName.AttrString2);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(RelationshipEntity1BasePropertyName.AttrString2, value);
			}
			else if (propertyName == RelationshipEntity1PropertyName.Name)
			{
				AppendPropertyName(RelationshipEntity1BasePropertyName.Name);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(RelationshipEntity1BasePropertyName.Name, value);
			}
			else if (propertyName == RelationshipEntity1PropertyName.Status)
			{
				AppendPropertyName(RelationshipEntity1BasePropertyName.Status);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(RelationshipEntity1BasePropertyName.Status, value);
			}
			else if (propertyName == RelationshipEntity1PropertyName.CreateTimestamp)
			{
				AppendPropertyName(RelationshipEntity1BasePropertyName.CreateTimestamp);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(RelationshipEntity1BasePropertyName.CreateTimestamp, value);
			}
			else if (propertyName == RelationshipEntity1PropertyName.CreateUser)
			{
				AppendPropertyName(RelationshipEntity1BasePropertyName.CreateUser);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(RelationshipEntity1BasePropertyName.CreateUser, value);
			}
			else if (propertyName == RelationshipEntity1PropertyName.LastUpdateTimestamp)
			{
				AppendPropertyName(RelationshipEntity1BasePropertyName.LastUpdateTimestamp);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(RelationshipEntity1BasePropertyName.LastUpdateTimestamp, value);
			}
			else if (propertyName == RelationshipEntity1PropertyName.UpdateId)
			{
				AppendPropertyName(RelationshipEntity1BasePropertyName.UpdateId);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(RelationshipEntity1BasePropertyName.UpdateId, value);
			}
			else if (propertyName == RelationshipEntity1PropertyName.LastUpdateUser)
			{
				AppendPropertyName(RelationshipEntity1BasePropertyName.LastUpdateUser);
				Append(" ");
				AppendOperator(expressionOperator);
				Append(" ");
				AppendPropertyValue(RelationshipEntity1BasePropertyName.LastUpdateUser, value);
			}
			return (SearchCondition)this;
		}

		public virtual SearchCondition AppendConstant(DbType dbType, object value)
		{
			return AppendConstant(new QueryConstant(dbType, value));
		}

		public virtual SearchCondition AppendConstant(QueryConstant constant)
		{
			Append(ParamPlaceholderString);
			this.ConstantList.Add(constant);
			return (SearchCondition)this;
		}

		public virtual SearchCondition AppendPropertyName(Attachment1BasePropertyName propertyName)
		{
			Append("[");
			Append(Attachment1BasePropertyNameMapper.GetColumnName(propertyName));
			Append("]");
			return (SearchCondition)this;
		}

		public virtual SearchCondition AppendPropertyName(DependentEntity1BasePropertyName propertyName)
		{
			Append("[");
			Append(DependentEntity1BasePropertyNameMapper.GetColumnName(propertyName));
			Append("]");
			return (SearchCondition)this;
		}

		public virtual SearchCondition AppendPropertyName(DependentEntity2BasePropertyName propertyName)
		{
			Append("[");
			Append(DependentEntity2BasePropertyNameMapper.GetColumnName(propertyName));
			Append("]");
			return (SearchCondition)this;
		}

		public virtual SearchCondition AppendPropertyName(IndependentEntity1BasePropertyName propertyName)
		{
			Append("[");
			Append(IndependentEntity1BasePropertyNameMapper.GetColumnName(propertyName));
			Append("]");
			return (SearchCondition)this;
		}

		public virtual SearchCondition AppendPropertyName(IndependentEntity2BasePropertyName propertyName)
		{
			Append("[");
			Append(IndependentEntity2BasePropertyNameMapper.GetColumnName(propertyName));
			Append("]");
			return (SearchCondition)this;
		}

		public virtual SearchCondition AppendPropertyName(RelationshipEntity1BasePropertyName propertyName)
		{
			Append("[");
			Append(RelationshipEntity1BasePropertyNameMapper.GetColumnName(propertyName));
			Append("]");
			return (SearchCondition)this;
		}

		public virtual SearchCondition AppendPropertyValue(Attachment1BasePropertyName propertyName, object value)
		{
			AppendConstant(Attachment1BasePropertyNameMapper.GetDbType(propertyName), value);
			return (SearchCondition)this;
		}

		public virtual SearchCondition AppendPropertyValue(DependentEntity1BasePropertyName propertyName, object value)
		{
			AppendConstant(DependentEntity1BasePropertyNameMapper.GetDbType(propertyName), value);
			return (SearchCondition)this;
		}

		public virtual SearchCondition AppendPropertyValue(DependentEntity2BasePropertyName propertyName, object value)
		{
			AppendConstant(DependentEntity2BasePropertyNameMapper.GetDbType(propertyName), value);
			return (SearchCondition)this;
		}

		public virtual SearchCondition AppendPropertyValue(IndependentEntity1BasePropertyName propertyName, object value)
		{
			AppendConstant(IndependentEntity1BasePropertyNameMapper.GetDbType(propertyName), value);
			return (SearchCondition)this;
		}

		public virtual SearchCondition AppendPropertyValue(IndependentEntity2BasePropertyName propertyName, object value)
		{
			AppendConstant(IndependentEntity2BasePropertyNameMapper.GetDbType(propertyName), value);
			return (SearchCondition)this;
		}

		public virtual SearchCondition AppendPropertyValue(RelationshipEntity1BasePropertyName propertyName, object value)
		{
			AppendConstant(RelationshipEntity1BasePropertyNameMapper.GetDbType(propertyName), value);
			return (SearchCondition)this;
		}

		public virtual string GetText()
		{
			return this.conditionStringBuilder.ToString();
		}

		//
		// Summary:
		//     Converts the value of this instance to a System.String.
		//
		// Returns:
		//     A string whose value is the same as this instance.
		public override string ToString()
		{
			return this.conditionStringBuilder.ToString();
		}

		// Made virtual because (for example) a more powerful version could check the condition to see if it would always evaluate to true.
		public virtual bool IsNullCondition()
		{
			return (this.conditionStringBuilder.Length == 0);
		}

	}
}
