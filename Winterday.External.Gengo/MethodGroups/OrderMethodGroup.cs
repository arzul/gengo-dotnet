﻿//
// OrderEndpoint.cs
//
// Author:
//       Jarl Erik Schmidt <github@jarlerik.com>
//
// Copyright (c) 2013 Jarl Erik Schmidt
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

namespace Winterday.External.Gengo.MethodGroups
{
    using System;
    using System.Threading.Tasks;

    using Newtonsoft.Json.Linq;

    using Winterday.External.Gengo.Payloads;
    using Winterday.External.Gengo.Properties;

    /// <summary>
    /// Provides access to methods in the
    /// <a href="http://developers.gengo.com/v2/order/">Order</a>
    /// method group.
    /// </summary>
    public class OrderMethodGroup
    {
        internal const string UriPartOrder = "translate/order/";

        readonly IGengoClient _client;

        internal OrderMethodGroup(IGengoClient client)
        {
            if (client == null)
                throw new ArgumentNullException("client");

            _client = client;
        }

        /// <summary>
        /// Gets information about an order, its constituent jobs
        /// and their statuses
        /// </summary>
        /// <param name="orderId">The order ID</param>
        /// <returns>Task yielding order information</returns>
        public async Task<Order> Get(int orderId)
        {
            var obj = await _client.GetJsonAsync<JObject>(
                UriPartOrder + orderId, true);

            if (obj == null)
                throw new Exception(
                    Resources.ServiceDidNotReturnExpectedValue);

            return new Order(obj.Value<JObject>("order"));
        }

        /// <summary>
        /// Cancels all the jobs in an order. This assumes that they
        /// have not already been started by a translator
        /// </summary>
        /// <param name="orderId">The order ID</param>
        /// <returns>Task yielding no value</returns>
        public async Task Delete(int orderId)
        {
            await _client.DeleteAsync<JObject>(UriPartOrder + orderId);
        }
    }
}
