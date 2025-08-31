namespace sti_student_patient_information_system.Properties {
    using System;

    internal class Resources {
        private static System.Resources.ResourceManager resourceMan;
        private static System.Globalization.CultureInfo resourceCulture;

        internal Resources() { }

        internal static System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    resourceMan = new System.Resources.ResourceManager("sti_student_patient_information_system.Properties.Resources", typeof(Resources).Assembly);
                }
                return resourceMan;
            }
        }

        internal static System.Drawing.Bitmap bell {
            get { return ((System.Drawing.Bitmap)(ResourceManager.GetObject("bell", resourceCulture))); }
        }

        internal static System.Drawing.Bitmap user {
            get { return ((System.Drawing.Bitmap)(ResourceManager.GetObject("user", resourceCulture))); }
        }

        internal static System.Drawing.Bitmap std {
            get { return ((System.Drawing.Bitmap)(ResourceManager.GetObject("std", resourceCulture))); }
        }

        internal static System.Drawing.Bitmap logo {
            get { return ((System.Drawing.Bitmap)(ResourceManager.GetObject("logo", resourceCulture))); }
        }
    }
}
