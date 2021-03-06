﻿using System;
using MFiles.VAF.MultiserverMode;

namespace MFiles.VAF.Extensions.MultiServerMode
{
	public partial class TaskQueueBackgroundOperationManager
	{
		/// <summary>
		/// Creates a new background operation and starts it. The background operation runs the given method at given intervals.
		/// </summary>
		/// <param name="name">The name of the operation.</param>
		/// <param name="interval">The target interval between method calls. If the method call takes longer than the interval, the method will be invoked immediately after the previous method call returns.</param>
		/// <param name="method">The method to invoke at given intervals.</param>
		/// <returns>A scheduled background operation.</returns>
		public TaskQueueBackgroundOperation StartRecurringBackgroundOperation
		(
			string name,
			TimeSpan interval,
			Action method
		)
		{
			return this.StartRecurringBackgroundOperation
			(
				name,
				interval,
				(j, d) => method()
			);
		}

		/// <summary>
		/// Creates a new background operation and starts it. The background operation runs the given method at given intervals.
		/// </summary>
		/// <param name="name">The name of the operation.</param>
		/// <param name="interval">The target interval between method calls. If the method call takes longer than the interval, the method will be invoked immediately after the previous method call returns.</param>
		/// <param name="method">The method to invoke at given intervals.</param>
		/// <returns>A scheduled background operation.</returns>
		public TaskQueueBackgroundOperation StartRecurringBackgroundOperation
		(
			string name,
			TimeSpan interval,
			Action<TaskProcessorJob> method
		)
		{
			return this.StartRecurringBackgroundOperation
			(
				name,
				interval,
				(j, d) => method(j)
			);
		}

		/// <summary>
		/// Creates a new background operation and starts it. The background operation runs the given method at given intervals.
		/// </summary>
		/// <param name="name">The name of the operation.</param>
		/// <param name="interval">The target interval between method calls. If the method call takes longer than the interval, the method will be invoked immediately after the previous method call returns.</param>
		/// <param name="method">The method to invoke at given intervals.</param>
		/// <param name="directive">The directive to pass to the job.</param>
		/// <returns>A started background operation.</returns>
		public TaskQueueBackgroundOperation StartRecurringBackgroundOperation
		(
			string name,
			TimeSpan interval,
			Action<TaskProcessorJob, TaskQueueDirective> method,
			TaskQueueDirective directive = null
		)
		{
			return this.StartRecurringBackgroundOperation<TaskQueueDirective>
			(
				name,
				interval,
				method,
				directive
			);
		}

		/// <summary>
		/// Creates a new background operation and starts it. The background operation runs the given method at given intervals.
		/// </summary>
		/// <param name="name">The name of the operation.</param>
		/// <param name="interval">The target interval between method calls. If the method call takes longer than the interval, the method will be invoked immediately after the previous method call returns.</param>
		/// <param name="method">The method to invoke at given intervals.</param>
		/// <param name="directive">The directive to pass to the job.</param>
		/// <returns>A started background operation.</returns>
		public TaskQueueBackgroundOperation<TDirective> StartRecurringBackgroundOperation<TDirective>
		(
			string name,
			TimeSpan interval,
			Action<TaskProcessorJob, TDirective> method,
			TDirective directive = null
		)
			where TDirective : TaskQueueDirective
		{
			// Create the background operation.
			var backgroundOperation = this.CreateBackgroundOperation
			(
				name,
				method
			);

			// Start it running.
			backgroundOperation.RunAtIntervals(interval, directive);

			// Return the background operation.
			return backgroundOperation;
		}
	}
}