#region License
// 
// Copyright (c) 2007-2009, Sean Chambers <schambers80@gmail.com>
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion

using FluentMigrator.Builders.Delete.Column;
using FluentMigrator.Builders.Delete.ForeignKey;
using FluentMigrator.Builders.Delete.Table;
using FluentMigrator.Expressions;
using FluentMigrator.Infrastructure;

namespace FluentMigrator.Builders.Delete
{
	public class DeleteExpressionRoot : IDeleteExpressionRoot
	{
		private readonly IMigrationContext _context;

		public DeleteExpressionRoot(IMigrationContext context)
		{
			_context = context;
		}

		public void Schema(string schemaName)
		{
			var expression = new DeleteSchemaExpression { SchemaName = schemaName };
			_context.Expressions.Add(expression);
		}

		public IInSchemaSyntax Table(string tableName)
		{
			var expression = new DeleteTableExpression { TableName = tableName };
			_context.Expressions.Add(expression);
			return new DeleteTableExpressionBuilder(expression);
		}

		public IDeleteColumnFromTableSyntax Column(string columnName)
		{
			var expression = new DeleteColumnExpression { ColumnName = columnName };
			_context.Expressions.Add(expression);
			return new DeleteColumnExpressionBuilder(expression);
		}

		public IDeleteForeignKeyFromTableSyntax ForeignKey()
		{
			var expression = new DeleteForeignKeyExpression();
			_context.Expressions.Add(expression);
			return new DeleteForeignKeyExpressionBuilder(expression);
		}

		public IDeleteForeignKeyOnTableSyntax ForeignKey(string foreignKeyName)
		{
			var expression = new DeleteForeignKeyExpression { ForeignKey = { Name = foreignKeyName } };
			_context.Expressions.Add(expression);
			return new DeleteForeignKeyExpressionBuilder(expression);
		}
	}
}