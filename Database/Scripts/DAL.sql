if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spget_attachment_1]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spget_attachment_1]
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_NULLS OFF
GO

CREATE PROCEDURE [dbo].[spget_attachment_1]
@p_attachment_1_id INT,
@p_attachment_notes NVARCHAR(4000) OUTPUT,
@p_attachment_type NVARCHAR(100) OUTPUT,
@p_attr_bool_1 BIT OUTPUT,
@p_attr_datetime_1 DATETIME OUTPUT,
@p_attr_integer_1 INT OUTPUT,
@p_attr_string_1 NVARCHAR(200) OUTPUT,
@p_attr_string_2 NVARCHAR(200) OUTPUT,
@p_file_attachment_is_null BIT OUTPUT,
@p_file_name NVARCHAR(350) OUTPUT,
@p_name NVARCHAR(100) OUTPUT,
@p_status NVARCHAR(100) OUTPUT,
@p_dependent_entity_1_id INT OUTPUT,
@p_create_datetime DATETIME OUTPUT,
@p_create_user NVARCHAR(50) OUTPUT,
@p_update_datetime DATETIME OUTPUT,
@p_update_id INT OUTPUT,
@p_update_user NVARCHAR(50) OUTPUT,
@p_rc_ INT OUTPUT
--WITH ENCRYPTION
AS
SELECT
@p_attachment_notes = [attachment_notes],
@p_attachment_type = [attachment_type],
@p_attr_bool_1 = [attr_bool_1],
@p_attr_datetime_1 = [attr_datetime_1],
@p_attr_integer_1 = [attr_integer_1],
@p_attr_string_1 = [attr_string_1],
@p_attr_string_2 = [attr_string_2],
@p_file_attachment_is_null = (CAST((CASE WHEN ([file_attachment] IS NULL) THEN 1 ELSE 0 END) AS BIT)),
@p_file_name = [file_name],
@p_name = [name],
@p_status = [status],
@p_dependent_entity_1_id = [dependent_entity_1_id],
@p_create_datetime = [create_datetime],
@p_create_user = [create_user],
@p_update_datetime = [update_datetime],
@p_update_id = [update_id],
@p_update_user = [update_user]
FROM
[attachment_1]
WHERE
[attachment_1_id] = @p_attachment_1_id;

IF @@ROWCOUNT = 1
	SELECT @p_rc_ = 1
ELSE
	SELECT @p_rc_ = 0
GO

SET QUOTED_IDENTIFIER OFF
GO

SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spget_dependent_entity_1]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spget_dependent_entity_1]
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_NULLS OFF
GO

CREATE PROCEDURE [dbo].[spget_dependent_entity_1]
@p_dependent_entity_1_id INT,
@p_attr_bool_1 BIT OUTPUT,
@p_attr_datetime_1 DATETIME OUTPUT,
@p_attr_integer_1 INT OUTPUT,
@p_attr_string_1 NVARCHAR(200) OUTPUT,
@p_attr_string_2 NVARCHAR(200) OUTPUT,
@p_name NVARCHAR(100) OUTPUT,
@p_status NVARCHAR(100) OUTPUT,
@p_independent_entity_1_id INT OUTPUT,
@p_create_datetime DATETIME OUTPUT,
@p_create_user NVARCHAR(50) OUTPUT,
@p_update_datetime DATETIME OUTPUT,
@p_update_id INT OUTPUT,
@p_update_user NVARCHAR(50) OUTPUT,
@p_rc_ INT OUTPUT
--WITH ENCRYPTION
AS
SELECT
@p_attr_bool_1 = [attr_bool_1],
@p_attr_datetime_1 = [attr_datetime_1],
@p_attr_integer_1 = [attr_integer_1],
@p_attr_string_1 = [attr_string_1],
@p_attr_string_2 = [attr_string_2],
@p_name = [name],
@p_status = [status],
@p_independent_entity_1_id = [independent_entity_1_id],
@p_create_datetime = [create_datetime],
@p_create_user = [create_user],
@p_update_datetime = [update_datetime],
@p_update_id = [update_id],
@p_update_user = [update_user]
FROM
[dependent_entity_1]
WHERE
[dependent_entity_1_id] = @p_dependent_entity_1_id;

IF @@ROWCOUNT = 1
	SELECT @p_rc_ = 1
ELSE
	SELECT @p_rc_ = 0
GO

SET QUOTED_IDENTIFIER OFF
GO

SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spget_dependent_entity_2]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spget_dependent_entity_2]
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_NULLS OFF
GO

CREATE PROCEDURE [dbo].[spget_dependent_entity_2]
@p_dependent_entity_2_id INT,
@p_attr_bool_1 BIT OUTPUT,
@p_attr_datetime_1 DATETIME OUTPUT,
@p_attr_integer_1 INT OUTPUT,
@p_attr_string_1 NVARCHAR(200) OUTPUT,
@p_attr_string_2 NVARCHAR(200) OUTPUT,
@p_name NVARCHAR(100) OUTPUT,
@p_status NVARCHAR(100) OUTPUT,
@p_dependent_entity_1_id INT OUTPUT,
@p_create_datetime DATETIME OUTPUT,
@p_create_user NVARCHAR(50) OUTPUT,
@p_update_datetime DATETIME OUTPUT,
@p_update_id INT OUTPUT,
@p_update_user NVARCHAR(50) OUTPUT,
@p_rc_ INT OUTPUT
--WITH ENCRYPTION
AS
SELECT
@p_attr_bool_1 = [attr_bool_1],
@p_attr_datetime_1 = [attr_datetime_1],
@p_attr_integer_1 = [attr_integer_1],
@p_attr_string_1 = [attr_string_1],
@p_attr_string_2 = [attr_string_2],
@p_name = [name],
@p_status = [status],
@p_dependent_entity_1_id = [dependent_entity_1_id],
@p_create_datetime = [create_datetime],
@p_create_user = [create_user],
@p_update_datetime = [update_datetime],
@p_update_id = [update_id],
@p_update_user = [update_user]
FROM
[dependent_entity_2]
WHERE
[dependent_entity_2_id] = @p_dependent_entity_2_id;

IF @@ROWCOUNT = 1
	SELECT @p_rc_ = 1
ELSE
	SELECT @p_rc_ = 0
GO

SET QUOTED_IDENTIFIER OFF
GO

SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spget_independent_entity_1]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spget_independent_entity_1]
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_NULLS OFF
GO

CREATE PROCEDURE [dbo].[spget_independent_entity_1]
@p_independent_entity_1_id INT,
@p_attr_bool_1 BIT OUTPUT,
@p_attr_datetime_1 DATETIME OUTPUT,
@p_attr_integer_1 INT OUTPUT,
@p_attr_string_1 NVARCHAR(200) OUTPUT,
@p_attr_string_2 NVARCHAR(200) OUTPUT,
@p_name NVARCHAR(100) OUTPUT,
@p_status NVARCHAR(100) OUTPUT,
@p_create_datetime DATETIME OUTPUT,
@p_create_user NVARCHAR(50) OUTPUT,
@p_update_datetime DATETIME OUTPUT,
@p_update_id INT OUTPUT,
@p_update_user NVARCHAR(50) OUTPUT,
@p_rc_ INT OUTPUT
--WITH ENCRYPTION
AS
SELECT
@p_attr_bool_1 = [attr_bool_1],
@p_attr_datetime_1 = [attr_datetime_1],
@p_attr_integer_1 = [attr_integer_1],
@p_attr_string_1 = [attr_string_1],
@p_attr_string_2 = [attr_string_2],
@p_name = [name],
@p_status = [status],
@p_create_datetime = [create_datetime],
@p_create_user = [create_user],
@p_update_datetime = [update_datetime],
@p_update_id = [update_id],
@p_update_user = [update_user]
FROM
[independent_entity_1]
WHERE
[independent_entity_1_id] = @p_independent_entity_1_id;

IF @@ROWCOUNT = 1
	SELECT @p_rc_ = 1
ELSE
	SELECT @p_rc_ = 0
GO

SET QUOTED_IDENTIFIER OFF
GO

SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spget_independent_entity_2]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spget_independent_entity_2]
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_NULLS OFF
GO

CREATE PROCEDURE [dbo].[spget_independent_entity_2]
@p_independent_entity_2_id INT,
@p_attr_bool_1 BIT OUTPUT,
@p_attr_datetime_1 DATETIME OUTPUT,
@p_attr_integer_1 INT OUTPUT,
@p_attr_string_1 NVARCHAR(200) OUTPUT,
@p_attr_string_2 NVARCHAR(200) OUTPUT,
@p_name NVARCHAR(100) OUTPUT,
@p_status NVARCHAR(100) OUTPUT,
@p_create_datetime DATETIME OUTPUT,
@p_create_user NVARCHAR(50) OUTPUT,
@p_update_datetime DATETIME OUTPUT,
@p_update_id INT OUTPUT,
@p_update_user NVARCHAR(50) OUTPUT,
@p_rc_ INT OUTPUT
--WITH ENCRYPTION
AS
SELECT
@p_attr_bool_1 = [attr_bool_1],
@p_attr_datetime_1 = [attr_datetime_1],
@p_attr_integer_1 = [attr_integer_1],
@p_attr_string_1 = [attr_string_1],
@p_attr_string_2 = [attr_string_2],
@p_name = [name],
@p_status = [status],
@p_create_datetime = [create_datetime],
@p_create_user = [create_user],
@p_update_datetime = [update_datetime],
@p_update_id = [update_id],
@p_update_user = [update_user]
FROM
[independent_entity_2]
WHERE
[independent_entity_2_id] = @p_independent_entity_2_id;

IF @@ROWCOUNT = 1
	SELECT @p_rc_ = 1
ELSE
	SELECT @p_rc_ = 0
GO

SET QUOTED_IDENTIFIER OFF
GO

SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spget_relationship_entity_1]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spget_relationship_entity_1]
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_NULLS OFF
GO

CREATE PROCEDURE [dbo].[spget_relationship_entity_1]
@p_relationship_entity_1_id INT,
@p_attr_bool_1 BIT OUTPUT,
@p_attr_datetime_1 DATETIME OUTPUT,
@p_attr_integer_1 INT OUTPUT,
@p_attr_string_1 NVARCHAR(200) OUTPUT,
@p_attr_string_2 NVARCHAR(200) OUTPUT,
@p_name NVARCHAR(100) OUTPUT,
@p_status NVARCHAR(100) OUTPUT,
@p_dependent_entity_2_id INT OUTPUT,
@p_independent_entity_2_id INT OUTPUT,
@p_create_datetime DATETIME OUTPUT,
@p_create_user NVARCHAR(50) OUTPUT,
@p_update_datetime DATETIME OUTPUT,
@p_update_id INT OUTPUT,
@p_update_user NVARCHAR(50) OUTPUT,
@p_rc_ INT OUTPUT
--WITH ENCRYPTION
AS
SELECT
@p_attr_bool_1 = [attr_bool_1],
@p_attr_datetime_1 = [attr_datetime_1],
@p_attr_integer_1 = [attr_integer_1],
@p_attr_string_1 = [attr_string_1],
@p_attr_string_2 = [attr_string_2],
@p_name = [name],
@p_status = [status],
@p_dependent_entity_2_id = [dependent_entity_2_id],
@p_independent_entity_2_id = [independent_entity_2_id],
@p_create_datetime = [create_datetime],
@p_create_user = [create_user],
@p_update_datetime = [update_datetime],
@p_update_id = [update_id],
@p_update_user = [update_user]
FROM
[relationship_entity_1]
WHERE
[relationship_entity_1_id] = @p_relationship_entity_1_id;

IF @@ROWCOUNT = 1
	SELECT @p_rc_ = 1
ELSE
	SELECT @p_rc_ = 0
GO

SET QUOTED_IDENTIFIER OFF
GO

SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spget_attachment_1_blob]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spget_attachment_1_blob]
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_NULLS OFF
GO

CREATE PROCEDURE [dbo].[spget_attachment_1_blob]
@p_attachment_1_id INT,
@p_ignore_collision_ BIT,
@p_update_id_ INT,
@p_column_name_ NVARCHAR(128),
@p_rc_ INT OUTPUT,
@p_update_ts_ DATETIME OUTPUT,
@p_user_ NVARCHAR(50) OUTPUT,
@p_blob_ VARBINARY(MAX) OUTPUT
--WITH ENCRYPTION
AS

IF @p_column_name_ = 'file_attachment'
	BEGIN
		IF @p_ignore_collision_ = 0
			BEGIN
				SELECT
				@p_blob_ = [file_attachment]
				FROM
				[attachment_1]
				WHERE
				[attachment_1_id] = @p_attachment_1_id AND
				[update_id] = @p_update_id_;
			END
		ELSE
			BEGIN
				SELECT
				@p_blob_ = [file_attachment]
				FROM
				[attachment_1]
				WHERE
				[attachment_1_id] = @p_attachment_1_id;
			END
		SELECT @p_rc_ = @@ROWCOUNT;
	END

IF @p_rc_ = 0
	BEGIN
		-- Collision detected.
		-- Get information about the collision to return to the caller.

		SELECT
		@p_update_ts_ = [update_datetime],
		@p_user_ = [update_user]
		FROM
		[attachment_1]
		WHERE
		[attachment_1_id] = @p_attachment_1_id;

		IF @@rowcount = 0
			BEGIN
				-- The object has been physically deleted.
				-- Since collision detection is on, the object having been deleted is an error to report back to the caller.
				SELECT @p_rc_ = 3;
				SELECT @p_update_ts_ = null;
				SELECT @p_user_ = null;
			END
		ELSE
			BEGIN
				-- The object has been updated by another session.
				SELECT @p_rc_ = 2;
			END
	END
GO

SET QUOTED_IDENTIFIER OFF
GO

SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spinsert_attachment_1]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spinsert_attachment_1]
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_NULLS OFF
GO

CREATE PROCEDURE [dbo].[spinsert_attachment_1]
@p_attachment_notes NVARCHAR(4000),
@p_attachment_type NVARCHAR(100),
@p_attr_bool_1 BIT,
@p_attr_datetime_1 DATETIME,
@p_attr_integer_1 INT,
@p_attr_string_1 NVARCHAR(200),
@p_attr_string_2 NVARCHAR(200),
@p_file_attachment VARBINARY(MAX),
@p_file_name NVARCHAR(350),
@p_name NVARCHAR(100),
@p_status NVARCHAR(100),
@p_dependent_entity_1_id INT,
@p_user_ NVARCHAR(50),
@p_attachment_1_id INT OUTPUT,
@p_update_ts_ DATETIME OUTPUT,
@p_update_id_ INT OUTPUT
--WITH ENCRYPTION
AS

SELECT @p_update_ts_ = GETDATE();

SELECT @p_update_id_ = 0;

INSERT INTO [attachment_1] (
[attachment_notes],
[attachment_type],
[attr_bool_1],
[attr_datetime_1],
[attr_integer_1],
[attr_string_1],
[attr_string_2],
[file_attachment],
[file_name],
[name],
[status],
[dependent_entity_1_id],
[create_datetime],
[create_user],
[update_datetime],
[update_user],
[update_id]
) VALUES (
@p_attachment_notes,
@p_attachment_type,
@p_attr_bool_1,
@p_attr_datetime_1,
@p_attr_integer_1,
@p_attr_string_1,
@p_attr_string_2,
@p_file_attachment,
@p_file_name,
@p_name,
@p_status,
@p_dependent_entity_1_id,
@p_update_ts_,
@p_user_,
@p_update_ts_,
@p_user_,
@p_update_id_
);

SET @p_attachment_1_id = CAST(SCOPE_IDENTITY() AS INT);
GO

SET QUOTED_IDENTIFIER OFF
GO

SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spinsert_dependent_entity_1]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spinsert_dependent_entity_1]
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_NULLS OFF
GO

CREATE PROCEDURE [dbo].[spinsert_dependent_entity_1]
@p_attr_bool_1 BIT,
@p_attr_datetime_1 DATETIME,
@p_attr_integer_1 INT,
@p_attr_string_1 NVARCHAR(200),
@p_attr_string_2 NVARCHAR(200),
@p_name NVARCHAR(100),
@p_status NVARCHAR(100),
@p_independent_entity_1_id INT,
@p_user_ NVARCHAR(50),
@p_dependent_entity_1_id INT OUTPUT,
@p_update_ts_ DATETIME OUTPUT,
@p_update_id_ INT OUTPUT
--WITH ENCRYPTION
AS

SELECT @p_update_ts_ = GETDATE();

SELECT @p_update_id_ = 0;

INSERT INTO [dependent_entity_1] (
[attr_bool_1],
[attr_datetime_1],
[attr_integer_1],
[attr_string_1],
[attr_string_2],
[name],
[status],
[independent_entity_1_id],
[create_datetime],
[create_user],
[update_datetime],
[update_user],
[update_id]
) VALUES (
@p_attr_bool_1,
@p_attr_datetime_1,
@p_attr_integer_1,
@p_attr_string_1,
@p_attr_string_2,
@p_name,
@p_status,
@p_independent_entity_1_id,
@p_update_ts_,
@p_user_,
@p_update_ts_,
@p_user_,
@p_update_id_
);

SET @p_dependent_entity_1_id = CAST(SCOPE_IDENTITY() AS INT);
GO

SET QUOTED_IDENTIFIER OFF
GO

SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spinsert_dependent_entity_2]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spinsert_dependent_entity_2]
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_NULLS OFF
GO

CREATE PROCEDURE [dbo].[spinsert_dependent_entity_2]
@p_attr_bool_1 BIT,
@p_attr_datetime_1 DATETIME,
@p_attr_integer_1 INT,
@p_attr_string_1 NVARCHAR(200),
@p_attr_string_2 NVARCHAR(200),
@p_name NVARCHAR(100),
@p_status NVARCHAR(100),
@p_dependent_entity_1_id INT,
@p_user_ NVARCHAR(50),
@p_dependent_entity_2_id INT OUTPUT,
@p_update_ts_ DATETIME OUTPUT,
@p_update_id_ INT OUTPUT
--WITH ENCRYPTION
AS

SELECT @p_update_ts_ = GETDATE();

SELECT @p_update_id_ = 0;

INSERT INTO [dependent_entity_2] (
[attr_bool_1],
[attr_datetime_1],
[attr_integer_1],
[attr_string_1],
[attr_string_2],
[name],
[status],
[dependent_entity_1_id],
[create_datetime],
[create_user],
[update_datetime],
[update_user],
[update_id]
) VALUES (
@p_attr_bool_1,
@p_attr_datetime_1,
@p_attr_integer_1,
@p_attr_string_1,
@p_attr_string_2,
@p_name,
@p_status,
@p_dependent_entity_1_id,
@p_update_ts_,
@p_user_,
@p_update_ts_,
@p_user_,
@p_update_id_
);

SET @p_dependent_entity_2_id = CAST(SCOPE_IDENTITY() AS INT);
GO

SET QUOTED_IDENTIFIER OFF
GO

SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spinsert_independent_entity_1]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spinsert_independent_entity_1]
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_NULLS OFF
GO

CREATE PROCEDURE [dbo].[spinsert_independent_entity_1]
@p_attr_bool_1 BIT,
@p_attr_datetime_1 DATETIME,
@p_attr_integer_1 INT,
@p_attr_string_1 NVARCHAR(200),
@p_attr_string_2 NVARCHAR(200),
@p_name NVARCHAR(100),
@p_status NVARCHAR(100),
@p_user_ NVARCHAR(50),
@p_independent_entity_1_id INT OUTPUT,
@p_update_ts_ DATETIME OUTPUT,
@p_update_id_ INT OUTPUT
--WITH ENCRYPTION
AS

SELECT @p_update_ts_ = GETDATE();

SELECT @p_update_id_ = 0;

INSERT INTO [independent_entity_1] (
[attr_bool_1],
[attr_datetime_1],
[attr_integer_1],
[attr_string_1],
[attr_string_2],
[name],
[status],
[create_datetime],
[create_user],
[update_datetime],
[update_user],
[update_id]
) VALUES (
@p_attr_bool_1,
@p_attr_datetime_1,
@p_attr_integer_1,
@p_attr_string_1,
@p_attr_string_2,
@p_name,
@p_status,
@p_update_ts_,
@p_user_,
@p_update_ts_,
@p_user_,
@p_update_id_
);

SET @p_independent_entity_1_id = CAST(SCOPE_IDENTITY() AS INT);
GO

SET QUOTED_IDENTIFIER OFF
GO

SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spinsert_independent_entity_2]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spinsert_independent_entity_2]
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_NULLS OFF
GO

CREATE PROCEDURE [dbo].[spinsert_independent_entity_2]
@p_attr_bool_1 BIT,
@p_attr_datetime_1 DATETIME,
@p_attr_integer_1 INT,
@p_attr_string_1 NVARCHAR(200),
@p_attr_string_2 NVARCHAR(200),
@p_name NVARCHAR(100),
@p_status NVARCHAR(100),
@p_user_ NVARCHAR(50),
@p_independent_entity_2_id INT OUTPUT,
@p_update_ts_ DATETIME OUTPUT,
@p_update_id_ INT OUTPUT
--WITH ENCRYPTION
AS

SELECT @p_update_ts_ = GETDATE();

SELECT @p_update_id_ = 0;

INSERT INTO [independent_entity_2] (
[attr_bool_1],
[attr_datetime_1],
[attr_integer_1],
[attr_string_1],
[attr_string_2],
[name],
[status],
[create_datetime],
[create_user],
[update_datetime],
[update_user],
[update_id]
) VALUES (
@p_attr_bool_1,
@p_attr_datetime_1,
@p_attr_integer_1,
@p_attr_string_1,
@p_attr_string_2,
@p_name,
@p_status,
@p_update_ts_,
@p_user_,
@p_update_ts_,
@p_user_,
@p_update_id_
);

SET @p_independent_entity_2_id = CAST(SCOPE_IDENTITY() AS INT);
GO

SET QUOTED_IDENTIFIER OFF
GO

SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spinsert_relationship_entity_1]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spinsert_relationship_entity_1]
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_NULLS OFF
GO

CREATE PROCEDURE [dbo].[spinsert_relationship_entity_1]
@p_attr_bool_1 BIT,
@p_attr_datetime_1 DATETIME,
@p_attr_integer_1 INT,
@p_attr_string_1 NVARCHAR(200),
@p_attr_string_2 NVARCHAR(200),
@p_name NVARCHAR(100),
@p_status NVARCHAR(100),
@p_dependent_entity_2_id INT,
@p_independent_entity_2_id INT,
@p_user_ NVARCHAR(50),
@p_relationship_entity_1_id INT OUTPUT,
@p_update_ts_ DATETIME OUTPUT,
@p_update_id_ INT OUTPUT
--WITH ENCRYPTION
AS

SELECT @p_update_ts_ = GETDATE();

SELECT @p_update_id_ = 0;

INSERT INTO [relationship_entity_1] (
[attr_bool_1],
[attr_datetime_1],
[attr_integer_1],
[attr_string_1],
[attr_string_2],
[name],
[status],
[dependent_entity_2_id],
[independent_entity_2_id],
[create_datetime],
[create_user],
[update_datetime],
[update_user],
[update_id]
) VALUES (
@p_attr_bool_1,
@p_attr_datetime_1,
@p_attr_integer_1,
@p_attr_string_1,
@p_attr_string_2,
@p_name,
@p_status,
@p_dependent_entity_2_id,
@p_independent_entity_2_id,
@p_update_ts_,
@p_user_,
@p_update_ts_,
@p_user_,
@p_update_id_
);

SET @p_relationship_entity_1_id = CAST(SCOPE_IDENTITY() AS INT);
GO

SET QUOTED_IDENTIFIER OFF
GO

SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spupdate_attachment_1]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spupdate_attachment_1]
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_NULLS OFF
GO

CREATE PROCEDURE [dbo].[spupdate_attachment_1]
@p_attachment_1_id INT,
@p_attachment_notes NVARCHAR(4000),
@p_attachment_type NVARCHAR(100),
@p_attr_bool_1 BIT,
@p_attr_datetime_1 DATETIME,
@p_attr_integer_1 INT,
@p_attr_string_1 NVARCHAR(200),
@p_attr_string_2 NVARCHAR(200),
@p_file_attachment VARBINARY(MAX),
@p_file_attachment_no_update BIT,
@p_file_name NVARCHAR(350),
@p_name NVARCHAR(100),
@p_status NVARCHAR(100),
@p_dependent_entity_1_id INT,
@p_ignore_collision_ BIT,
@p_rc_ INT OUTPUT,
@p_update_ts_ DATETIME OUTPUT,
@p_user_ NVARCHAR(50) OUTPUT,
@p_update_id_ INT OUTPUT
--WITH ENCRYPTION
AS
DECLARE @v_new_update_id INT;

-- Determine the new update timestamp.
SELECT @p_update_ts_ = GETDATE();

-- Update record.

DECLARE @v_update_successful BIT;
SELECT @v_update_successful = 0;
IF @p_ignore_collision_ = 0
	BEGIN
		-- Update WITH collision detection.

		-- Determine the new update id.

		SELECT @v_new_update_id = @p_update_id_;
		IF @v_new_update_id = 2147483647
			SELECT @v_new_update_id = 0;
		ELSE
			SELECT @v_new_update_id = @v_new_update_id + 1;

		-- Perform update WITH update_id criteria.
		-- On-demand-load BLOBs are updated in separate commands.
		UPDATE [attachment_1]
		SET
		[attachment_notes] = @p_attachment_notes,
		[attachment_type] = @p_attachment_type,
		[attr_bool_1] = @p_attr_bool_1,
		[attr_datetime_1] = @p_attr_datetime_1,
		[attr_integer_1] = @p_attr_integer_1,
		[attr_string_1] = @p_attr_string_1,
		[attr_string_2] = @p_attr_string_2,
		[file_name] = @p_file_name,
		[name] = @p_name,
		[status] = @p_status,
		[dependent_entity_1_id] = @p_dependent_entity_1_id,
		[update_datetime] = @p_update_ts_,
		[update_user] = @p_user_,
		[update_id] = @v_new_update_id
		WHERE
		[attachment_1_id] = @p_attachment_1_id AND
		[update_id] = @p_update_id_;

		-- Determine whether update successful. It won't be if there was a collision.
		IF (@@rowcount = 0)
			SELECT @v_update_successful = 0;
		ELSE
			SELECT @v_update_successful = 1;

		-- Update on-demand-load BLOB columns if there are any.

		IF @p_file_attachment_no_update = 0
			BEGIN
				UPDATE [attachment_1]
				SET
				[file_attachment] = @p_file_attachment
				WHERE
				[attachment_1_id] = @p_attachment_1_id AND
				[update_id] = @v_new_update_id;
			END
	END
ELSE
	BEGIN
		-- Update WITHOUT collision detection.
		-- The update_id passed by the caller will be ignored.

		DECLARE c_attachment_1 CURSOR
		LOCAL
		FORWARD_ONLY
		KEYSET
		OPTIMISTIC
		FOR
			SELECT
			[update_id]
			FROM
			[attachment_1]
			WHERE
			[attachment_1_id] = @p_attachment_1_id
		FOR UPDATE;

		OPEN c_attachment_1;
		FETCH NEXT FROM c_attachment_1 INTO @v_new_update_id;
		IF @@FETCH_STATUS = 0
			BEGIN
				-- Record was returned by the cursor.

				-- Determine the new update id.
				IF @v_new_update_id = 2147483647
					SELECT @v_new_update_id = 0;
				ELSE
					SELECT @v_new_update_id = @v_new_update_id + 1;

				-- Perform update. Optimistic locking will ensure this update succeeds only if the record is not updated by another transaction, thus update_id will be correctly updated.
				-- On-demand-load BLOBs are updated in separate commands.
				UPDATE [attachment_1]
				SET
				[attachment_notes] = @p_attachment_notes,
				[attachment_type] = @p_attachment_type,
				[attr_bool_1] = @p_attr_bool_1,
				[attr_datetime_1] = @p_attr_datetime_1,
				[attr_integer_1] = @p_attr_integer_1,
				[attr_string_1] = @p_attr_string_1,
				[attr_string_2] = @p_attr_string_2,
				[file_name] = @p_file_name,
				[name] = @p_name,
				[status] = @p_status,
				[dependent_entity_1_id] = @p_dependent_entity_1_id,
				[update_datetime] = @p_update_ts_,
				[update_user] = @p_user_,
				[update_id] = @v_new_update_id
				WHERE CURRENT OF c_attachment_1;

				-- Update on-demand-load BLOB columns if there are any.

				IF @p_file_attachment_no_update = 0
					BEGIN
						UPDATE [attachment_1]
						SET
						[file_attachment] = @p_file_attachment
						WHERE CURRENT OF c_attachment_1;
					END

				SELECT @v_update_successful = 1;
			END
		ELSE
			BEGIN
				-- No record returned by the cursor implying that the object has been physically deleted.
				SELECT @v_update_successful = 0;
			END

		CLOSE c_attachment_1;
		DEALLOCATE c_attachment_1;
	END

IF @v_update_successful = 0
	BEGIN
		-- Collision detected.

		IF @p_ignore_collision_ = 1
			BEGIN
				-- Collision can't be ignored because the object has been physically removed from the database. There are no records to update.
				SELECT @p_rc_ = 3;
				SELECT @p_update_ts_ = null;
				SELECT @p_user_ = null;
			END
		ELSE
			-- Get information about the collision to return to the caller.
			BEGIN
				SELECT
				@p_update_ts_ = [update_datetime],
				@p_user_ = [update_user]
				FROM
				[attachment_1]
				WHERE
				[attachment_1_id] = @p_attachment_1_id;

				IF @@rowcount = 0
					BEGIN
						-- The object has been physically deleted.
						SELECT @p_rc_ = 3;
						SELECT @p_update_ts_ = null;
						SELECT @p_user_ = null;
					END
				ELSE
					BEGIN
						-- The object has been updated by another session.
						SELECT @p_rc_ = 2;
					END

				SELECT @p_update_id_ = null;
			END
	END
ELSE
	BEGIN
		-- Save successful. No collision detected.

		SELECT @p_rc_ = 1;
		SELECT @p_update_id_ = @v_new_update_id; -- Return to caller the new update id of the object just saved.
	END
GO

SET QUOTED_IDENTIFIER OFF
GO

SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spupdate_dependent_entity_1]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spupdate_dependent_entity_1]
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_NULLS OFF
GO

CREATE PROCEDURE [dbo].[spupdate_dependent_entity_1]
@p_dependent_entity_1_id INT,
@p_attr_bool_1 BIT,
@p_attr_datetime_1 DATETIME,
@p_attr_integer_1 INT,
@p_attr_string_1 NVARCHAR(200),
@p_attr_string_2 NVARCHAR(200),
@p_name NVARCHAR(100),
@p_status NVARCHAR(100),
@p_independent_entity_1_id INT,
@p_ignore_collision_ BIT,
@p_rc_ INT OUTPUT,
@p_update_ts_ DATETIME OUTPUT,
@p_user_ NVARCHAR(50) OUTPUT,
@p_update_id_ INT OUTPUT
--WITH ENCRYPTION
AS
DECLARE @v_new_update_id INT;

-- Determine the new update timestamp.
SELECT @p_update_ts_ = GETDATE();

-- Update record.

DECLARE @v_update_successful BIT;
SELECT @v_update_successful = 0;
IF @p_ignore_collision_ = 0
	BEGIN
		-- Update WITH collision detection.

		-- Determine the new update id.

		SELECT @v_new_update_id = @p_update_id_;
		IF @v_new_update_id = 2147483647
			SELECT @v_new_update_id = 0;
		ELSE
			SELECT @v_new_update_id = @v_new_update_id + 1;

		-- Perform update WITH update_id criteria.
		-- On-demand-load BLOBs are updated in separate commands.
		UPDATE [dependent_entity_1]
		SET
		[attr_bool_1] = @p_attr_bool_1,
		[attr_datetime_1] = @p_attr_datetime_1,
		[attr_integer_1] = @p_attr_integer_1,
		[attr_string_1] = @p_attr_string_1,
		[attr_string_2] = @p_attr_string_2,
		[name] = @p_name,
		[status] = @p_status,
		[independent_entity_1_id] = @p_independent_entity_1_id,
		[update_datetime] = @p_update_ts_,
		[update_user] = @p_user_,
		[update_id] = @v_new_update_id
		WHERE
		[dependent_entity_1_id] = @p_dependent_entity_1_id AND
		[update_id] = @p_update_id_;

		-- Determine whether update successful. It won't be if there was a collision.
		IF (@@rowcount = 0)
			SELECT @v_update_successful = 0;
		ELSE
			SELECT @v_update_successful = 1;

		-- Update on-demand-load BLOB columns if there are any.

	END
ELSE
	BEGIN
		-- Update WITHOUT collision detection.
		-- The update_id passed by the caller will be ignored.

		DECLARE c_dependent_entity_1 CURSOR
		LOCAL
		FORWARD_ONLY
		KEYSET
		OPTIMISTIC
		FOR
			SELECT
			[update_id]
			FROM
			[dependent_entity_1]
			WHERE
			[dependent_entity_1_id] = @p_dependent_entity_1_id
		FOR UPDATE;

		OPEN c_dependent_entity_1;
		FETCH NEXT FROM c_dependent_entity_1 INTO @v_new_update_id;
		IF @@FETCH_STATUS = 0
			BEGIN
				-- Record was returned by the cursor.

				-- Determine the new update id.
				IF @v_new_update_id = 2147483647
					SELECT @v_new_update_id = 0;
				ELSE
					SELECT @v_new_update_id = @v_new_update_id + 1;

				-- Perform update. Optimistic locking will ensure this update succeeds only if the record is not updated by another transaction, thus update_id will be correctly updated.
				-- On-demand-load BLOBs are updated in separate commands.
				UPDATE [dependent_entity_1]
				SET
				[attr_bool_1] = @p_attr_bool_1,
				[attr_datetime_1] = @p_attr_datetime_1,
				[attr_integer_1] = @p_attr_integer_1,
				[attr_string_1] = @p_attr_string_1,
				[attr_string_2] = @p_attr_string_2,
				[name] = @p_name,
				[status] = @p_status,
				[independent_entity_1_id] = @p_independent_entity_1_id,
				[update_datetime] = @p_update_ts_,
				[update_user] = @p_user_,
				[update_id] = @v_new_update_id
				WHERE CURRENT OF c_dependent_entity_1;

				-- Update on-demand-load BLOB columns if there are any.


				SELECT @v_update_successful = 1;
			END
		ELSE
			BEGIN
				-- No record returned by the cursor implying that the object has been physically deleted.
				SELECT @v_update_successful = 0;
			END

		CLOSE c_dependent_entity_1;
		DEALLOCATE c_dependent_entity_1;
	END

IF @v_update_successful = 0
	BEGIN
		-- Collision detected.

		IF @p_ignore_collision_ = 1
			BEGIN
				-- Collision can't be ignored because the object has been physically removed from the database. There are no records to update.
				SELECT @p_rc_ = 3;
				SELECT @p_update_ts_ = null;
				SELECT @p_user_ = null;
			END
		ELSE
			-- Get information about the collision to return to the caller.
			BEGIN
				SELECT
				@p_update_ts_ = [update_datetime],
				@p_user_ = [update_user]
				FROM
				[dependent_entity_1]
				WHERE
				[dependent_entity_1_id] = @p_dependent_entity_1_id;

				IF @@rowcount = 0
					BEGIN
						-- The object has been physically deleted.
						SELECT @p_rc_ = 3;
						SELECT @p_update_ts_ = null;
						SELECT @p_user_ = null;
					END
				ELSE
					BEGIN
						-- The object has been updated by another session.
						SELECT @p_rc_ = 2;
					END

				SELECT @p_update_id_ = null;
			END
	END
ELSE
	BEGIN
		-- Save successful. No collision detected.

		SELECT @p_rc_ = 1;
		SELECT @p_update_id_ = @v_new_update_id; -- Return to caller the new update id of the object just saved.
	END
GO

SET QUOTED_IDENTIFIER OFF
GO

SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spupdate_dependent_entity_2]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spupdate_dependent_entity_2]
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_NULLS OFF
GO

CREATE PROCEDURE [dbo].[spupdate_dependent_entity_2]
@p_dependent_entity_2_id INT,
@p_attr_bool_1 BIT,
@p_attr_datetime_1 DATETIME,
@p_attr_integer_1 INT,
@p_attr_string_1 NVARCHAR(200),
@p_attr_string_2 NVARCHAR(200),
@p_name NVARCHAR(100),
@p_status NVARCHAR(100),
@p_dependent_entity_1_id INT,
@p_ignore_collision_ BIT,
@p_rc_ INT OUTPUT,
@p_update_ts_ DATETIME OUTPUT,
@p_user_ NVARCHAR(50) OUTPUT,
@p_update_id_ INT OUTPUT
--WITH ENCRYPTION
AS
DECLARE @v_new_update_id INT;

-- Determine the new update timestamp.
SELECT @p_update_ts_ = GETDATE();

-- Update record.

DECLARE @v_update_successful BIT;
SELECT @v_update_successful = 0;
IF @p_ignore_collision_ = 0
	BEGIN
		-- Update WITH collision detection.

		-- Determine the new update id.

		SELECT @v_new_update_id = @p_update_id_;
		IF @v_new_update_id = 2147483647
			SELECT @v_new_update_id = 0;
		ELSE
			SELECT @v_new_update_id = @v_new_update_id + 1;

		-- Perform update WITH update_id criteria.
		-- On-demand-load BLOBs are updated in separate commands.
		UPDATE [dependent_entity_2]
		SET
		[attr_bool_1] = @p_attr_bool_1,
		[attr_datetime_1] = @p_attr_datetime_1,
		[attr_integer_1] = @p_attr_integer_1,
		[attr_string_1] = @p_attr_string_1,
		[attr_string_2] = @p_attr_string_2,
		[name] = @p_name,
		[status] = @p_status,
		[dependent_entity_1_id] = @p_dependent_entity_1_id,
		[update_datetime] = @p_update_ts_,
		[update_user] = @p_user_,
		[update_id] = @v_new_update_id
		WHERE
		[dependent_entity_2_id] = @p_dependent_entity_2_id AND
		[update_id] = @p_update_id_;

		-- Determine whether update successful. It won't be if there was a collision.
		IF (@@rowcount = 0)
			SELECT @v_update_successful = 0;
		ELSE
			SELECT @v_update_successful = 1;

		-- Update on-demand-load BLOB columns if there are any.

	END
ELSE
	BEGIN
		-- Update WITHOUT collision detection.
		-- The update_id passed by the caller will be ignored.

		DECLARE c_dependent_entity_2 CURSOR
		LOCAL
		FORWARD_ONLY
		KEYSET
		OPTIMISTIC
		FOR
			SELECT
			[update_id]
			FROM
			[dependent_entity_2]
			WHERE
			[dependent_entity_2_id] = @p_dependent_entity_2_id
		FOR UPDATE;

		OPEN c_dependent_entity_2;
		FETCH NEXT FROM c_dependent_entity_2 INTO @v_new_update_id;
		IF @@FETCH_STATUS = 0
			BEGIN
				-- Record was returned by the cursor.

				-- Determine the new update id.
				IF @v_new_update_id = 2147483647
					SELECT @v_new_update_id = 0;
				ELSE
					SELECT @v_new_update_id = @v_new_update_id + 1;

				-- Perform update. Optimistic locking will ensure this update succeeds only if the record is not updated by another transaction, thus update_id will be correctly updated.
				-- On-demand-load BLOBs are updated in separate commands.
				UPDATE [dependent_entity_2]
				SET
				[attr_bool_1] = @p_attr_bool_1,
				[attr_datetime_1] = @p_attr_datetime_1,
				[attr_integer_1] = @p_attr_integer_1,
				[attr_string_1] = @p_attr_string_1,
				[attr_string_2] = @p_attr_string_2,
				[name] = @p_name,
				[status] = @p_status,
				[dependent_entity_1_id] = @p_dependent_entity_1_id,
				[update_datetime] = @p_update_ts_,
				[update_user] = @p_user_,
				[update_id] = @v_new_update_id
				WHERE CURRENT OF c_dependent_entity_2;

				-- Update on-demand-load BLOB columns if there are any.


				SELECT @v_update_successful = 1;
			END
		ELSE
			BEGIN
				-- No record returned by the cursor implying that the object has been physically deleted.
				SELECT @v_update_successful = 0;
			END

		CLOSE c_dependent_entity_2;
		DEALLOCATE c_dependent_entity_2;
	END

IF @v_update_successful = 0
	BEGIN
		-- Collision detected.

		IF @p_ignore_collision_ = 1
			BEGIN
				-- Collision can't be ignored because the object has been physically removed from the database. There are no records to update.
				SELECT @p_rc_ = 3;
				SELECT @p_update_ts_ = null;
				SELECT @p_user_ = null;
			END
		ELSE
			-- Get information about the collision to return to the caller.
			BEGIN
				SELECT
				@p_update_ts_ = [update_datetime],
				@p_user_ = [update_user]
				FROM
				[dependent_entity_2]
				WHERE
				[dependent_entity_2_id] = @p_dependent_entity_2_id;

				IF @@rowcount = 0
					BEGIN
						-- The object has been physically deleted.
						SELECT @p_rc_ = 3;
						SELECT @p_update_ts_ = null;
						SELECT @p_user_ = null;
					END
				ELSE
					BEGIN
						-- The object has been updated by another session.
						SELECT @p_rc_ = 2;
					END

				SELECT @p_update_id_ = null;
			END
	END
ELSE
	BEGIN
		-- Save successful. No collision detected.

		SELECT @p_rc_ = 1;
		SELECT @p_update_id_ = @v_new_update_id; -- Return to caller the new update id of the object just saved.
	END
GO

SET QUOTED_IDENTIFIER OFF
GO

SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spupdate_independent_entity_1]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spupdate_independent_entity_1]
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_NULLS OFF
GO

CREATE PROCEDURE [dbo].[spupdate_independent_entity_1]
@p_independent_entity_1_id INT,
@p_attr_bool_1 BIT,
@p_attr_datetime_1 DATETIME,
@p_attr_integer_1 INT,
@p_attr_string_1 NVARCHAR(200),
@p_attr_string_2 NVARCHAR(200),
@p_name NVARCHAR(100),
@p_status NVARCHAR(100),
@p_ignore_collision_ BIT,
@p_rc_ INT OUTPUT,
@p_update_ts_ DATETIME OUTPUT,
@p_user_ NVARCHAR(50) OUTPUT,
@p_update_id_ INT OUTPUT
--WITH ENCRYPTION
AS
DECLARE @v_new_update_id INT;

-- Determine the new update timestamp.
SELECT @p_update_ts_ = GETDATE();

-- Update record.

DECLARE @v_update_successful BIT;
SELECT @v_update_successful = 0;
IF @p_ignore_collision_ = 0
	BEGIN
		-- Update WITH collision detection.

		-- Determine the new update id.

		SELECT @v_new_update_id = @p_update_id_;
		IF @v_new_update_id = 2147483647
			SELECT @v_new_update_id = 0;
		ELSE
			SELECT @v_new_update_id = @v_new_update_id + 1;

		-- Perform update WITH update_id criteria.
		-- On-demand-load BLOBs are updated in separate commands.
		UPDATE [independent_entity_1]
		SET
		[attr_bool_1] = @p_attr_bool_1,
		[attr_datetime_1] = @p_attr_datetime_1,
		[attr_integer_1] = @p_attr_integer_1,
		[attr_string_1] = @p_attr_string_1,
		[attr_string_2] = @p_attr_string_2,
		[name] = @p_name,
		[status] = @p_status,
		[update_datetime] = @p_update_ts_,
		[update_user] = @p_user_,
		[update_id] = @v_new_update_id
		WHERE
		[independent_entity_1_id] = @p_independent_entity_1_id AND
		[update_id] = @p_update_id_;

		-- Determine whether update successful. It won't be if there was a collision.
		IF (@@rowcount = 0)
			SELECT @v_update_successful = 0;
		ELSE
			SELECT @v_update_successful = 1;

		-- Update on-demand-load BLOB columns if there are any.

	END
ELSE
	BEGIN
		-- Update WITHOUT collision detection.
		-- The update_id passed by the caller will be ignored.

		DECLARE c_independent_entity_1 CURSOR
		LOCAL
		FORWARD_ONLY
		KEYSET
		OPTIMISTIC
		FOR
			SELECT
			[update_id]
			FROM
			[independent_entity_1]
			WHERE
			[independent_entity_1_id] = @p_independent_entity_1_id
		FOR UPDATE;

		OPEN c_independent_entity_1;
		FETCH NEXT FROM c_independent_entity_1 INTO @v_new_update_id;
		IF @@FETCH_STATUS = 0
			BEGIN
				-- Record was returned by the cursor.

				-- Determine the new update id.
				IF @v_new_update_id = 2147483647
					SELECT @v_new_update_id = 0;
				ELSE
					SELECT @v_new_update_id = @v_new_update_id + 1;

				-- Perform update. Optimistic locking will ensure this update succeeds only if the record is not updated by another transaction, thus update_id will be correctly updated.
				-- On-demand-load BLOBs are updated in separate commands.
				UPDATE [independent_entity_1]
				SET
				[attr_bool_1] = @p_attr_bool_1,
				[attr_datetime_1] = @p_attr_datetime_1,
				[attr_integer_1] = @p_attr_integer_1,
				[attr_string_1] = @p_attr_string_1,
				[attr_string_2] = @p_attr_string_2,
				[name] = @p_name,
				[status] = @p_status,
				[update_datetime] = @p_update_ts_,
				[update_user] = @p_user_,
				[update_id] = @v_new_update_id
				WHERE CURRENT OF c_independent_entity_1;

				-- Update on-demand-load BLOB columns if there are any.


				SELECT @v_update_successful = 1;
			END
		ELSE
			BEGIN
				-- No record returned by the cursor implying that the object has been physically deleted.
				SELECT @v_update_successful = 0;
			END

		CLOSE c_independent_entity_1;
		DEALLOCATE c_independent_entity_1;
	END

IF @v_update_successful = 0
	BEGIN
		-- Collision detected.

		IF @p_ignore_collision_ = 1
			BEGIN
				-- Collision can't be ignored because the object has been physically removed from the database. There are no records to update.
				SELECT @p_rc_ = 3;
				SELECT @p_update_ts_ = null;
				SELECT @p_user_ = null;
			END
		ELSE
			-- Get information about the collision to return to the caller.
			BEGIN
				SELECT
				@p_update_ts_ = [update_datetime],
				@p_user_ = [update_user]
				FROM
				[independent_entity_1]
				WHERE
				[independent_entity_1_id] = @p_independent_entity_1_id;

				IF @@rowcount = 0
					BEGIN
						-- The object has been physically deleted.
						SELECT @p_rc_ = 3;
						SELECT @p_update_ts_ = null;
						SELECT @p_user_ = null;
					END
				ELSE
					BEGIN
						-- The object has been updated by another session.
						SELECT @p_rc_ = 2;
					END

				SELECT @p_update_id_ = null;
			END
	END
ELSE
	BEGIN
		-- Save successful. No collision detected.

		SELECT @p_rc_ = 1;
		SELECT @p_update_id_ = @v_new_update_id; -- Return to caller the new update id of the object just saved.
	END
GO

SET QUOTED_IDENTIFIER OFF
GO

SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spupdate_independent_entity_2]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spupdate_independent_entity_2]
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_NULLS OFF
GO

CREATE PROCEDURE [dbo].[spupdate_independent_entity_2]
@p_independent_entity_2_id INT,
@p_attr_bool_1 BIT,
@p_attr_datetime_1 DATETIME,
@p_attr_integer_1 INT,
@p_attr_string_1 NVARCHAR(200),
@p_attr_string_2 NVARCHAR(200),
@p_name NVARCHAR(100),
@p_status NVARCHAR(100),
@p_ignore_collision_ BIT,
@p_rc_ INT OUTPUT,
@p_update_ts_ DATETIME OUTPUT,
@p_user_ NVARCHAR(50) OUTPUT,
@p_update_id_ INT OUTPUT
--WITH ENCRYPTION
AS
DECLARE @v_new_update_id INT;

-- Determine the new update timestamp.
SELECT @p_update_ts_ = GETDATE();

-- Update record.

DECLARE @v_update_successful BIT;
SELECT @v_update_successful = 0;
IF @p_ignore_collision_ = 0
	BEGIN
		-- Update WITH collision detection.

		-- Determine the new update id.

		SELECT @v_new_update_id = @p_update_id_;
		IF @v_new_update_id = 2147483647
			SELECT @v_new_update_id = 0;
		ELSE
			SELECT @v_new_update_id = @v_new_update_id + 1;

		-- Perform update WITH update_id criteria.
		-- On-demand-load BLOBs are updated in separate commands.
		UPDATE [independent_entity_2]
		SET
		[attr_bool_1] = @p_attr_bool_1,
		[attr_datetime_1] = @p_attr_datetime_1,
		[attr_integer_1] = @p_attr_integer_1,
		[attr_string_1] = @p_attr_string_1,
		[attr_string_2] = @p_attr_string_2,
		[name] = @p_name,
		[status] = @p_status,
		[update_datetime] = @p_update_ts_,
		[update_user] = @p_user_,
		[update_id] = @v_new_update_id
		WHERE
		[independent_entity_2_id] = @p_independent_entity_2_id AND
		[update_id] = @p_update_id_;

		-- Determine whether update successful. It won't be if there was a collision.
		IF (@@rowcount = 0)
			SELECT @v_update_successful = 0;
		ELSE
			SELECT @v_update_successful = 1;

		-- Update on-demand-load BLOB columns if there are any.

	END
ELSE
	BEGIN
		-- Update WITHOUT collision detection.
		-- The update_id passed by the caller will be ignored.

		DECLARE c_independent_entity_2 CURSOR
		LOCAL
		FORWARD_ONLY
		KEYSET
		OPTIMISTIC
		FOR
			SELECT
			[update_id]
			FROM
			[independent_entity_2]
			WHERE
			[independent_entity_2_id] = @p_independent_entity_2_id
		FOR UPDATE;

		OPEN c_independent_entity_2;
		FETCH NEXT FROM c_independent_entity_2 INTO @v_new_update_id;
		IF @@FETCH_STATUS = 0
			BEGIN
				-- Record was returned by the cursor.

				-- Determine the new update id.
				IF @v_new_update_id = 2147483647
					SELECT @v_new_update_id = 0;
				ELSE
					SELECT @v_new_update_id = @v_new_update_id + 1;

				-- Perform update. Optimistic locking will ensure this update succeeds only if the record is not updated by another transaction, thus update_id will be correctly updated.
				-- On-demand-load BLOBs are updated in separate commands.
				UPDATE [independent_entity_2]
				SET
				[attr_bool_1] = @p_attr_bool_1,
				[attr_datetime_1] = @p_attr_datetime_1,
				[attr_integer_1] = @p_attr_integer_1,
				[attr_string_1] = @p_attr_string_1,
				[attr_string_2] = @p_attr_string_2,
				[name] = @p_name,
				[status] = @p_status,
				[update_datetime] = @p_update_ts_,
				[update_user] = @p_user_,
				[update_id] = @v_new_update_id
				WHERE CURRENT OF c_independent_entity_2;

				-- Update on-demand-load BLOB columns if there are any.


				SELECT @v_update_successful = 1;
			END
		ELSE
			BEGIN
				-- No record returned by the cursor implying that the object has been physically deleted.
				SELECT @v_update_successful = 0;
			END

		CLOSE c_independent_entity_2;
		DEALLOCATE c_independent_entity_2;
	END

IF @v_update_successful = 0
	BEGIN
		-- Collision detected.

		IF @p_ignore_collision_ = 1
			BEGIN
				-- Collision can't be ignored because the object has been physically removed from the database. There are no records to update.
				SELECT @p_rc_ = 3;
				SELECT @p_update_ts_ = null;
				SELECT @p_user_ = null;
			END
		ELSE
			-- Get information about the collision to return to the caller.
			BEGIN
				SELECT
				@p_update_ts_ = [update_datetime],
				@p_user_ = [update_user]
				FROM
				[independent_entity_2]
				WHERE
				[independent_entity_2_id] = @p_independent_entity_2_id;

				IF @@rowcount = 0
					BEGIN
						-- The object has been physically deleted.
						SELECT @p_rc_ = 3;
						SELECT @p_update_ts_ = null;
						SELECT @p_user_ = null;
					END
				ELSE
					BEGIN
						-- The object has been updated by another session.
						SELECT @p_rc_ = 2;
					END

				SELECT @p_update_id_ = null;
			END
	END
ELSE
	BEGIN
		-- Save successful. No collision detected.

		SELECT @p_rc_ = 1;
		SELECT @p_update_id_ = @v_new_update_id; -- Return to caller the new update id of the object just saved.
	END
GO

SET QUOTED_IDENTIFIER OFF
GO

SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spupdate_relationship_entity_1]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spupdate_relationship_entity_1]
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_NULLS OFF
GO

CREATE PROCEDURE [dbo].[spupdate_relationship_entity_1]
@p_relationship_entity_1_id INT,
@p_attr_bool_1 BIT,
@p_attr_datetime_1 DATETIME,
@p_attr_integer_1 INT,
@p_attr_string_1 NVARCHAR(200),
@p_attr_string_2 NVARCHAR(200),
@p_name NVARCHAR(100),
@p_status NVARCHAR(100),
@p_dependent_entity_2_id INT,
@p_independent_entity_2_id INT,
@p_ignore_collision_ BIT,
@p_rc_ INT OUTPUT,
@p_update_ts_ DATETIME OUTPUT,
@p_user_ NVARCHAR(50) OUTPUT,
@p_update_id_ INT OUTPUT
--WITH ENCRYPTION
AS
DECLARE @v_new_update_id INT;

-- Determine the new update timestamp.
SELECT @p_update_ts_ = GETDATE();

-- Update record.

DECLARE @v_update_successful BIT;
SELECT @v_update_successful = 0;
IF @p_ignore_collision_ = 0
	BEGIN
		-- Update WITH collision detection.

		-- Determine the new update id.

		SELECT @v_new_update_id = @p_update_id_;
		IF @v_new_update_id = 2147483647
			SELECT @v_new_update_id = 0;
		ELSE
			SELECT @v_new_update_id = @v_new_update_id + 1;

		-- Perform update WITH update_id criteria.
		-- On-demand-load BLOBs are updated in separate commands.
		UPDATE [relationship_entity_1]
		SET
		[attr_bool_1] = @p_attr_bool_1,
		[attr_datetime_1] = @p_attr_datetime_1,
		[attr_integer_1] = @p_attr_integer_1,
		[attr_string_1] = @p_attr_string_1,
		[attr_string_2] = @p_attr_string_2,
		[name] = @p_name,
		[status] = @p_status,
		[dependent_entity_2_id] = @p_dependent_entity_2_id,
		[independent_entity_2_id] = @p_independent_entity_2_id,
		[update_datetime] = @p_update_ts_,
		[update_user] = @p_user_,
		[update_id] = @v_new_update_id
		WHERE
		[relationship_entity_1_id] = @p_relationship_entity_1_id AND
		[update_id] = @p_update_id_;

		-- Determine whether update successful. It won't be if there was a collision.
		IF (@@rowcount = 0)
			SELECT @v_update_successful = 0;
		ELSE
			SELECT @v_update_successful = 1;

		-- Update on-demand-load BLOB columns if there are any.

	END
ELSE
	BEGIN
		-- Update WITHOUT collision detection.
		-- The update_id passed by the caller will be ignored.

		DECLARE c_relationship_entity_1 CURSOR
		LOCAL
		FORWARD_ONLY
		KEYSET
		OPTIMISTIC
		FOR
			SELECT
			[update_id]
			FROM
			[relationship_entity_1]
			WHERE
			[relationship_entity_1_id] = @p_relationship_entity_1_id
		FOR UPDATE;

		OPEN c_relationship_entity_1;
		FETCH NEXT FROM c_relationship_entity_1 INTO @v_new_update_id;
		IF @@FETCH_STATUS = 0
			BEGIN
				-- Record was returned by the cursor.

				-- Determine the new update id.
				IF @v_new_update_id = 2147483647
					SELECT @v_new_update_id = 0;
				ELSE
					SELECT @v_new_update_id = @v_new_update_id + 1;

				-- Perform update. Optimistic locking will ensure this update succeeds only if the record is not updated by another transaction, thus update_id will be correctly updated.
				-- On-demand-load BLOBs are updated in separate commands.
				UPDATE [relationship_entity_1]
				SET
				[attr_bool_1] = @p_attr_bool_1,
				[attr_datetime_1] = @p_attr_datetime_1,
				[attr_integer_1] = @p_attr_integer_1,
				[attr_string_1] = @p_attr_string_1,
				[attr_string_2] = @p_attr_string_2,
				[name] = @p_name,
				[status] = @p_status,
				[dependent_entity_2_id] = @p_dependent_entity_2_id,
				[independent_entity_2_id] = @p_independent_entity_2_id,
				[update_datetime] = @p_update_ts_,
				[update_user] = @p_user_,
				[update_id] = @v_new_update_id
				WHERE CURRENT OF c_relationship_entity_1;

				-- Update on-demand-load BLOB columns if there are any.


				SELECT @v_update_successful = 1;
			END
		ELSE
			BEGIN
				-- No record returned by the cursor implying that the object has been physically deleted.
				SELECT @v_update_successful = 0;
			END

		CLOSE c_relationship_entity_1;
		DEALLOCATE c_relationship_entity_1;
	END

IF @v_update_successful = 0
	BEGIN
		-- Collision detected.

		IF @p_ignore_collision_ = 1
			BEGIN
				-- Collision can't be ignored because the object has been physically removed from the database. There are no records to update.
				SELECT @p_rc_ = 3;
				SELECT @p_update_ts_ = null;
				SELECT @p_user_ = null;
			END
		ELSE
			-- Get information about the collision to return to the caller.
			BEGIN
				SELECT
				@p_update_ts_ = [update_datetime],
				@p_user_ = [update_user]
				FROM
				[relationship_entity_1]
				WHERE
				[relationship_entity_1_id] = @p_relationship_entity_1_id;

				IF @@rowcount = 0
					BEGIN
						-- The object has been physically deleted.
						SELECT @p_rc_ = 3;
						SELECT @p_update_ts_ = null;
						SELECT @p_user_ = null;
					END
				ELSE
					BEGIN
						-- The object has been updated by another session.
						SELECT @p_rc_ = 2;
					END

				SELECT @p_update_id_ = null;
			END
	END
ELSE
	BEGIN
		-- Save successful. No collision detected.

		SELECT @p_rc_ = 1;
		SELECT @p_update_id_ = @v_new_update_id; -- Return to caller the new update id of the object just saved.
	END
GO

SET QUOTED_IDENTIFIER OFF
GO

SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spdelete_attachment_1]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spdelete_attachment_1]
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_NULLS OFF
GO

CREATE PROCEDURE [dbo].[spdelete_attachment_1]
@p_attachment_1_id INT,
@p_ignore_collision_ BIT,
@p_update_id_ INT,
@p_rc_ INT OUTPUT,
@p_update_ts_ DATETIME OUTPUT,
@p_user_ NVARCHAR(50) OUTPUT
--WITH ENCRYPTION
AS
-- Delete object.

DECLARE @v_update_successful BIT;
SELECT @v_update_successful = 0;
IF @p_ignore_collision_ = 0
	BEGIN
		-- Delete WITH collision detection.

		-- Perform delete WITH update_id criteria.
		DELETE
		FROM [attachment_1]
		WHERE
		[attachment_1_id] = @p_attachment_1_id AND
		[update_id] = @p_update_id_;

		-- Determine whether delete successful. It won't be if there was a collision.
		IF (@@rowcount = 0)
			SELECT @v_update_successful = 0;
		ELSE
			SELECT @v_update_successful = 1;
	END
ELSE
	BEGIN
		-- Delete WITHOUT collision detection.
		-- The update_id passed by the caller will be ignored.

		-- Perform delete WITHOUT update_id criteria.
		DELETE
		FROM [attachment_1]
		WHERE
		[attachment_1_id] = @p_attachment_1_id;

		-- Since collision detection is off, not concerned if object was actually deleted by the above call or by some other user.
		SELECT @v_update_successful = 1;
	END

IF @v_update_successful = 0
	BEGIN
		-- Collision detected.
		-- Get information about the collision to return to the caller.
		SELECT
		@p_update_ts_ = [update_datetime],
		@p_user_ = [update_user]
		FROM
		[attachment_1]
		WHERE
		[attachment_1_id] = @p_attachment_1_id;

		IF @@rowcount = 0
			BEGIN
				-- The object has been physically deleted.
				-- Since collision detection is on, the object having been deleted is an error to report back to the caller.
				SELECT @p_rc_ = 3;
				SELECT @p_update_ts_ = null;
				SELECT @p_user_ = null;
			END
		ELSE
			BEGIN
				-- The object has been updated by another session.
				SELECT @p_rc_ = 2;
			END
	END
ELSE
	BEGIN
		-- Delete successful. No collision detected.
		SELECT @p_rc_ = 1;
	END

GO

SET QUOTED_IDENTIFIER OFF
GO

SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spdelete_dependent_entity_1]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spdelete_dependent_entity_1]
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_NULLS OFF
GO

CREATE PROCEDURE [dbo].[spdelete_dependent_entity_1]
@p_dependent_entity_1_id INT,
@p_ignore_collision_ BIT,
@p_update_id_ INT,
@p_rc_ INT OUTPUT,
@p_update_ts_ DATETIME OUTPUT,
@p_user_ NVARCHAR(50) OUTPUT
--WITH ENCRYPTION
AS
-- Delete object.

DECLARE @v_update_successful BIT;
SELECT @v_update_successful = 0;
IF @p_ignore_collision_ = 0
	BEGIN
		-- Delete WITH collision detection.

		-- Perform delete WITH update_id criteria.
		DELETE
		FROM [dependent_entity_1]
		WHERE
		[dependent_entity_1_id] = @p_dependent_entity_1_id AND
		[update_id] = @p_update_id_;

		-- Determine whether delete successful. It won't be if there was a collision.
		IF (@@rowcount = 0)
			SELECT @v_update_successful = 0;
		ELSE
			SELECT @v_update_successful = 1;
	END
ELSE
	BEGIN
		-- Delete WITHOUT collision detection.
		-- The update_id passed by the caller will be ignored.

		-- Perform delete WITHOUT update_id criteria.
		DELETE
		FROM [dependent_entity_1]
		WHERE
		[dependent_entity_1_id] = @p_dependent_entity_1_id;

		-- Since collision detection is off, not concerned if object was actually deleted by the above call or by some other user.
		SELECT @v_update_successful = 1;
	END

IF @v_update_successful = 0
	BEGIN
		-- Collision detected.
		-- Get information about the collision to return to the caller.
		SELECT
		@p_update_ts_ = [update_datetime],
		@p_user_ = [update_user]
		FROM
		[dependent_entity_1]
		WHERE
		[dependent_entity_1_id] = @p_dependent_entity_1_id;

		IF @@rowcount = 0
			BEGIN
				-- The object has been physically deleted.
				-- Since collision detection is on, the object having been deleted is an error to report back to the caller.
				SELECT @p_rc_ = 3;
				SELECT @p_update_ts_ = null;
				SELECT @p_user_ = null;
			END
		ELSE
			BEGIN
				-- The object has been updated by another session.
				SELECT @p_rc_ = 2;
			END
	END
ELSE
	BEGIN
		-- Delete successful. No collision detected.
		SELECT @p_rc_ = 1;
	END

GO

SET QUOTED_IDENTIFIER OFF
GO

SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spdelete_dependent_entity_2]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spdelete_dependent_entity_2]
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_NULLS OFF
GO

CREATE PROCEDURE [dbo].[spdelete_dependent_entity_2]
@p_dependent_entity_2_id INT,
@p_ignore_collision_ BIT,
@p_update_id_ INT,
@p_rc_ INT OUTPUT,
@p_update_ts_ DATETIME OUTPUT,
@p_user_ NVARCHAR(50) OUTPUT
--WITH ENCRYPTION
AS
-- Delete object.

DECLARE @v_update_successful BIT;
SELECT @v_update_successful = 0;
IF @p_ignore_collision_ = 0
	BEGIN
		-- Delete WITH collision detection.

		-- Perform delete WITH update_id criteria.
		DELETE
		FROM [dependent_entity_2]
		WHERE
		[dependent_entity_2_id] = @p_dependent_entity_2_id AND
		[update_id] = @p_update_id_;

		-- Determine whether delete successful. It won't be if there was a collision.
		IF (@@rowcount = 0)
			SELECT @v_update_successful = 0;
		ELSE
			SELECT @v_update_successful = 1;
	END
ELSE
	BEGIN
		-- Delete WITHOUT collision detection.
		-- The update_id passed by the caller will be ignored.

		-- Perform delete WITHOUT update_id criteria.
		DELETE
		FROM [dependent_entity_2]
		WHERE
		[dependent_entity_2_id] = @p_dependent_entity_2_id;

		-- Since collision detection is off, not concerned if object was actually deleted by the above call or by some other user.
		SELECT @v_update_successful = 1;
	END

IF @v_update_successful = 0
	BEGIN
		-- Collision detected.
		-- Get information about the collision to return to the caller.
		SELECT
		@p_update_ts_ = [update_datetime],
		@p_user_ = [update_user]
		FROM
		[dependent_entity_2]
		WHERE
		[dependent_entity_2_id] = @p_dependent_entity_2_id;

		IF @@rowcount = 0
			BEGIN
				-- The object has been physically deleted.
				-- Since collision detection is on, the object having been deleted is an error to report back to the caller.
				SELECT @p_rc_ = 3;
				SELECT @p_update_ts_ = null;
				SELECT @p_user_ = null;
			END
		ELSE
			BEGIN
				-- The object has been updated by another session.
				SELECT @p_rc_ = 2;
			END
	END
ELSE
	BEGIN
		-- Delete successful. No collision detected.
		SELECT @p_rc_ = 1;
	END

GO

SET QUOTED_IDENTIFIER OFF
GO

SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spdelete_independent_entity_1]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spdelete_independent_entity_1]
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_NULLS OFF
GO

CREATE PROCEDURE [dbo].[spdelete_independent_entity_1]
@p_independent_entity_1_id INT,
@p_ignore_collision_ BIT,
@p_update_id_ INT,
@p_rc_ INT OUTPUT,
@p_update_ts_ DATETIME OUTPUT,
@p_user_ NVARCHAR(50) OUTPUT
--WITH ENCRYPTION
AS
-- Delete object.

DECLARE @v_update_successful BIT;
SELECT @v_update_successful = 0;
IF @p_ignore_collision_ = 0
	BEGIN
		-- Delete WITH collision detection.

		-- Perform delete WITH update_id criteria.
		DELETE
		FROM [independent_entity_1]
		WHERE
		[independent_entity_1_id] = @p_independent_entity_1_id AND
		[update_id] = @p_update_id_;

		-- Determine whether delete successful. It won't be if there was a collision.
		IF (@@rowcount = 0)
			SELECT @v_update_successful = 0;
		ELSE
			SELECT @v_update_successful = 1;
	END
ELSE
	BEGIN
		-- Delete WITHOUT collision detection.
		-- The update_id passed by the caller will be ignored.

		-- Perform delete WITHOUT update_id criteria.
		DELETE
		FROM [independent_entity_1]
		WHERE
		[independent_entity_1_id] = @p_independent_entity_1_id;

		-- Since collision detection is off, not concerned if object was actually deleted by the above call or by some other user.
		SELECT @v_update_successful = 1;
	END

IF @v_update_successful = 0
	BEGIN
		-- Collision detected.
		-- Get information about the collision to return to the caller.
		SELECT
		@p_update_ts_ = [update_datetime],
		@p_user_ = [update_user]
		FROM
		[independent_entity_1]
		WHERE
		[independent_entity_1_id] = @p_independent_entity_1_id;

		IF @@rowcount = 0
			BEGIN
				-- The object has been physically deleted.
				-- Since collision detection is on, the object having been deleted is an error to report back to the caller.
				SELECT @p_rc_ = 3;
				SELECT @p_update_ts_ = null;
				SELECT @p_user_ = null;
			END
		ELSE
			BEGIN
				-- The object has been updated by another session.
				SELECT @p_rc_ = 2;
			END
	END
ELSE
	BEGIN
		-- Delete successful. No collision detected.
		SELECT @p_rc_ = 1;
	END

GO

SET QUOTED_IDENTIFIER OFF
GO

SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spdelete_independent_entity_2]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spdelete_independent_entity_2]
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_NULLS OFF
GO

CREATE PROCEDURE [dbo].[spdelete_independent_entity_2]
@p_independent_entity_2_id INT,
@p_ignore_collision_ BIT,
@p_update_id_ INT,
@p_rc_ INT OUTPUT,
@p_update_ts_ DATETIME OUTPUT,
@p_user_ NVARCHAR(50) OUTPUT
--WITH ENCRYPTION
AS
-- Delete object.

DECLARE @v_update_successful BIT;
SELECT @v_update_successful = 0;
IF @p_ignore_collision_ = 0
	BEGIN
		-- Delete WITH collision detection.

		-- Perform delete WITH update_id criteria.
		DELETE
		FROM [independent_entity_2]
		WHERE
		[independent_entity_2_id] = @p_independent_entity_2_id AND
		[update_id] = @p_update_id_;

		-- Determine whether delete successful. It won't be if there was a collision.
		IF (@@rowcount = 0)
			SELECT @v_update_successful = 0;
		ELSE
			SELECT @v_update_successful = 1;
	END
ELSE
	BEGIN
		-- Delete WITHOUT collision detection.
		-- The update_id passed by the caller will be ignored.

		-- Perform delete WITHOUT update_id criteria.
		DELETE
		FROM [independent_entity_2]
		WHERE
		[independent_entity_2_id] = @p_independent_entity_2_id;

		-- Since collision detection is off, not concerned if object was actually deleted by the above call or by some other user.
		SELECT @v_update_successful = 1;
	END

IF @v_update_successful = 0
	BEGIN
		-- Collision detected.
		-- Get information about the collision to return to the caller.
		SELECT
		@p_update_ts_ = [update_datetime],
		@p_user_ = [update_user]
		FROM
		[independent_entity_2]
		WHERE
		[independent_entity_2_id] = @p_independent_entity_2_id;

		IF @@rowcount = 0
			BEGIN
				-- The object has been physically deleted.
				-- Since collision detection is on, the object having been deleted is an error to report back to the caller.
				SELECT @p_rc_ = 3;
				SELECT @p_update_ts_ = null;
				SELECT @p_user_ = null;
			END
		ELSE
			BEGIN
				-- The object has been updated by another session.
				SELECT @p_rc_ = 2;
			END
	END
ELSE
	BEGIN
		-- Delete successful. No collision detected.
		SELECT @p_rc_ = 1;
	END

GO

SET QUOTED_IDENTIFIER OFF
GO

SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spdelete_relationship_entity_1]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spdelete_relationship_entity_1]
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_NULLS OFF
GO

CREATE PROCEDURE [dbo].[spdelete_relationship_entity_1]
@p_relationship_entity_1_id INT,
@p_ignore_collision_ BIT,
@p_update_id_ INT,
@p_rc_ INT OUTPUT,
@p_update_ts_ DATETIME OUTPUT,
@p_user_ NVARCHAR(50) OUTPUT
--WITH ENCRYPTION
AS
-- Delete object.

DECLARE @v_update_successful BIT;
SELECT @v_update_successful = 0;
IF @p_ignore_collision_ = 0
	BEGIN
		-- Delete WITH collision detection.

		-- Perform delete WITH update_id criteria.
		DELETE
		FROM [relationship_entity_1]
		WHERE
		[relationship_entity_1_id] = @p_relationship_entity_1_id AND
		[update_id] = @p_update_id_;

		-- Determine whether delete successful. It won't be if there was a collision.
		IF (@@rowcount = 0)
			SELECT @v_update_successful = 0;
		ELSE
			SELECT @v_update_successful = 1;
	END
ELSE
	BEGIN
		-- Delete WITHOUT collision detection.
		-- The update_id passed by the caller will be ignored.

		-- Perform delete WITHOUT update_id criteria.
		DELETE
		FROM [relationship_entity_1]
		WHERE
		[relationship_entity_1_id] = @p_relationship_entity_1_id;

		-- Since collision detection is off, not concerned if object was actually deleted by the above call or by some other user.
		SELECT @v_update_successful = 1;
	END

IF @v_update_successful = 0
	BEGIN
		-- Collision detected.
		-- Get information about the collision to return to the caller.
		SELECT
		@p_update_ts_ = [update_datetime],
		@p_user_ = [update_user]
		FROM
		[relationship_entity_1]
		WHERE
		[relationship_entity_1_id] = @p_relationship_entity_1_id;

		IF @@rowcount = 0
			BEGIN
				-- The object has been physically deleted.
				-- Since collision detection is on, the object having been deleted is an error to report back to the caller.
				SELECT @p_rc_ = 3;
				SELECT @p_update_ts_ = null;
				SELECT @p_user_ = null;
			END
		ELSE
			BEGIN
				-- The object has been updated by another session.
				SELECT @p_rc_ = 2;
			END
	END
ELSE
	BEGIN
		-- Delete successful. No collision detected.
		SELECT @p_rc_ = 1;
	END

GO

SET QUOTED_IDENTIFIER OFF
GO

SET ANSI_NULLS ON
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[spattachment_1_delete_trigger]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
DROP TRIGGER [dbo].[spattachment_1_delete_trigger]
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[spdependent_entity_1_delete_trigger]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
DROP TRIGGER [dbo].[spdependent_entity_1_delete_trigger]
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[spdependent_entity_2_delete_trigger]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
DROP TRIGGER [dbo].[spdependent_entity_2_delete_trigger]
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[spindependent_entity_1_delete_trigger]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
DROP TRIGGER [dbo].[spindependent_entity_1_delete_trigger]
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[spindependent_entity_2_delete_trigger]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
DROP TRIGGER [dbo].[spindependent_entity_2_delete_trigger]
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[sprelationship_entity_1_delete_trigger]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
DROP TRIGGER [dbo].[sprelationship_entity_1_delete_trigger]
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[spbulk_erase_all]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[spbulk_erase_all]
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_NULLS OFF
GO

CREATE PROCEDURE [dbo].[spbulk_erase_all]
--WITH ENCRYPTION
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
	SET NOCOUNT ON;


	-- Cannot use TRUNCATE TABLE because it is not supported by SQL Server when foreign key constraints are defined.
	--DELETE FROM [dbo].[relationship_entity_1];
	--DELETE FROM [dbo].[dependent_entity_2];
	--DELETE FROM [dbo].[attachment_1];
	--DELETE FROM [dbo].[dependent_entity_1];
	--DELETE FROM [dbo].[independent_entity_1];
	--DELETE FROM [dbo].[independent_entity_2];
END
