﻿using System.Windows.Controls;

namespace SI_DevCenter.Helpers
{
    internal static class ClassExtended
    {
#if !NET
        public static string[] Split(this string _this, char separator, StringSplitOptions options)
        {
            return _this.Split([separator], options);
        }
        public static string[] Split(this string _this, string separator, StringSplitOptions options)
        {
            return _this.Split([separator], options);
        }
#endif
        public static TreeViewItem? ContainerFromItemRecursive(this ItemContainerGenerator root, object item)
        {
            var treeViewItem = root.ContainerFromItem(item) as TreeViewItem;
            if (treeViewItem is not null)
                return treeViewItem;
            foreach (var subItem in root.Items)
            {
                treeViewItem = root.ContainerFromItem(subItem) as TreeViewItem;
                var search = treeViewItem?.ItemContainerGenerator.ContainerFromItemRecursive(item);
                if (search is not null)
                    return search;
            }
            return null;
        }
    }
}
