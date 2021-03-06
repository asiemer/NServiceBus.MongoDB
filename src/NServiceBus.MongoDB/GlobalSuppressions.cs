// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GlobalSuppressions.cs" company="SharkByte Software">
//   The MIT License (MIT)
//   
//   Copyright (c) 2017 SharkByte Software
//   
//   Permission is hereby granted, free of charge, to any person obtaining a copy of
//   this software and associated documentation files (the "Software"), to deal in
//   the Software without restriction, including without limitation the rights to
//   use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
//   the Software, and to permit persons to whom the Software is furnished to do so,
//   subject to the following conditions:
//   
//   The above copyright notice and this permission notice shall be included in all
//   copies or substantial portions of the Software.
//   
//   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//   IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
//   FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
//   COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
//   IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
//   CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "NServiceBus.MongoDB.SubscriptionPersister", Justification = "Reviewied")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "NServiceBus.MongoDB.SagaPersister", Justification = "Reviewied")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "NServiceBus.MongoDB", Justification = "Reviewied")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Scope = "member", Target = "NServiceBus.MongoDB.SubscriptionPersister.Subscription.#Clients", Justification = "Reviewied")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Scope = "member", Target = "NServiceBus.MongoDB.SubscriptionPersister.Subscription.#Clients", Justification = "Reviewied")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "NServiceBus.MongoDB.TimeoutPersister", Justification = "Reviewed")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "OwningTimeoutManagerAndTime", Scope = "member", Target = "NServiceBus.MongoDB.TimeoutPersister.MongoTimeoutPersister.#EnsureTimeoutIndexes()", Justification = "Reviewed")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "OwningTimeoutManagerAndSagaIdAndTime", Scope = "member", Target = "NServiceBus.MongoDB.TimeoutPersister.MongoTimeoutPersister.#EnsureTimeoutIndexes()", Justification = "Reviewed")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "NServiceBus.MongoDB.Internals", Justification = "Reviewed")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "NServiceBus.MongoDB.Internals.MongoHelpers.#VerifyConnectionToMongoServer(NServiceBus.MongoDB.Internals.MongoClientAccessor)", Justification = "Reviewed")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "NServiceBus.MongoDB.DataBus", Justification = "Reviewed")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays", Scope = "member", Target = "NServiceBus.MongoDB.TimeoutPersister.TimeoutEntity.#State", Justification = "Reviewed")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Scope = "member", Target = "NServiceBus.MongoDB.TimeoutPersister.TimeoutEntity.#Headers", Justification = "Reviewed")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Scope = "member", Target = "NServiceBus.MongoDB.TimeoutPersister.MongoTimeoutPersister.#GetNextChunk(System.DateTime,System.DateTime&)", Justification = "Reviewed")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Part of the interface")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Justification = "Ok here.")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Scope = "member", Target = "NServiceBus.MongoDB.TimeoutPersister.MongoTimeoutPersister.#GetNextChunk(System.DateTime,System.DateTime&)", Justification = "Reviewed")]