// // using System.Collections;
// // using System.Collections.Generic;
// // using UnityEngine;

// // public class Panel : MonoBehaviour
// // {
// //     private bool isDestroyed = false;
// //     public void OpenPanel()
// //     {
// //         gameObject.SetActive(true);
// //     }
// //     public void ClosePanel()
// //     {
// //         gameObject.SetActive(false);
// //         if (isDestroyed)
// //         {
// //             Destroy(gameObject);
// //         }
// //     }
// // }

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Panel : MonoBehaviour
// {
//     public bool destroyOnClose = true;

//     public virtual void Open()
//     {
//         gameObject.SetActive(true);
//     }

//     public virtual void Close()
//     {
//         gameObject.SetActive(false);
//         if (destroyOnClose)
//         {
//             PanelManager.Instance.RemovePanel(name); 
//             Destroy(this.gameObject);
//         }
//     }
// }