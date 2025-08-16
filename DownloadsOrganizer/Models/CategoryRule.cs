using System.Collections.Generic;

namespace DownloadsOrganizer
{
    /// <summary>
    /// Defines the rule for a category, including which file extensions belong to it.
    /// </summary>
    public sealed class CategoryRule
    {
        public Category Category { get; }
        public HashSet<string> Extensions { get; }

        /// <summary>
        /// Initializes a new instance of CategoryRule.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <param name="extensions">List of file extensions for this category.</param>
        public CategoryRule(Category category, IEnumerable<string> extensions)
        {
            Category = category;
            Extensions = new HashSet<string>(extensions);
        }
    }
}
