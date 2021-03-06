﻿using System.Collections.Generic;
using SimpleNetNlp.Extensions;

namespace SimpleNetNlp
{
    /// <summary>
    /// A representation of a Document. Most blobs of raw text should become documents.
    /// </summary>
    public class Document
    {
        private edu.stanford.nlp.simple.Document nlpDoc;
        private List<Sentence> sentences;

        /// <summary>
        /// Create a new document from the passed in text.
        /// </summary>
        /// <param name="text">The text of the document.</param>
        public Document(string text)
        {
            nlpDoc = new edu.stanford.nlp.simple.Document(text);
        }

        /// <summary>
        /// Get the sentences in this document, as a list.
        /// </summary>
        public List<Sentence> Sentences
        {
            get
            {
                if (sentences == null)
                {
                    sentences = nlpDoc
                                    .sentences()
                                    .ToList<edu.stanford.nlp.simple.Sentence, Sentence>(x => new Sentence(x));
                }
                return sentences;
            }
        }

        public override string ToString()
        {
            return nlpDoc.toString();
        }
    }
}
