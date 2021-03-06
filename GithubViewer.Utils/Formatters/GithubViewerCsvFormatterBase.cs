﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using GithubViewer.Utils.Extensions;

namespace GithubViewer.Utils.Formatters
{
    /// <inheritdoc />
    /// <summary>
    /// Base class for formatting models from GithubViewer.Models
    /// </summary>
    /// <typeparam name="T">Type from GithubViewer.Models</typeparam>
    public abstract class GithubViewerCsvFormatterBase<T> : BufferedMediaTypeFormatter
    {
        protected GithubViewerCsvFormatterBase()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/simplecsv"));
        }

        public override bool CanReadType(Type type) =>
            false;

        public override bool CanWriteType(Type type)
        {
            var canWrite = type.IsTypeofOrIEnumerableOf<T>();
            return canWrite;
        }

        public override void WriteToStream(
            Type type,
            object value,
            Stream writeStream,
            HttpContent content)
        {
            using (var writer = new StreamWriter(writeStream))
            {
                if (value is IEnumerable<T> entities)
                {
                    WriteHeader(writer);
                    foreach (var entity in entities)
                    {
                        WriteItem(entity, writer);
                    }
                }
                else
                {
                    var entity = (T)value;
                    if (entity == null)
                    {
                        throw new InvalidOperationException("Cannot serialize type");
                    }

                    WriteHeader(writer);
                    WriteItem(entity, writer);
                }
            }
        }

        /// <summary>
        /// Write header into stream writer
        /// </summary>
        /// <param name="writer">stream writer</param>
        public abstract void WriteHeader(StreamWriter writer);

        /// <summary>
        /// Write single object into stream writer
        /// </summary>
        /// <param name="objectToSerialize">Object of type of T</param>
        /// <param name="writer">stream writer</param>
        public abstract void WriteItem(T objectToSerialize, StreamWriter writer);
    }
}