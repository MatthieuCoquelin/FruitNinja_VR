using UnityEngine;
using EzySlice;
using System;
using System.Collections.Generic;

public class Slicer : MonoBehaviour
{
    /// <summary>
    /// material for each fruits 
    /// </summary>
    [SerializeField] private List<Material> m_materialsAfterSlice;

    /// <summary>
    /// the element slice had a special mask 
    /// </summary>
    [SerializeField] private LayerMask m_sliceMask;
    private Material m_materialAfterSlice;

    /// <summary>
    /// reference to prefab explosion
    /// </summary>
    [SerializeField] private GameObject m_explosion;

    /// <summary>
    /// delegegate to make slice sound 
    /// </summary>
    public static event Action<int, string> OnSliceMakeSound;

    /// <summary>
    /// delegate to update score on slice 
    /// </summary>
    public static event Action<string> OnSliceUpdateScore;

    /// <summary>
    /// delegate to vibrite controller on slice 
    /// </summary>
    public static event Action<string, float, float> OnSliceVibrate;


    private void OnEnable()
    {
        //enable delegates of slice listener 
        SliceListener.OnSlicerEnter += SliceGameObject;
        SliceListener.OnSlicerExit += ResetSlice;

    }

    private void OnDisable()
    {
        //disable delegates of slice listener 
        SliceListener.OnSlicerEnter -= SliceGameObject;
        SliceListener.OnSlicerExit -= ResetSlice;
    }

    /// <summary>
    /// Perform slice
    /// </summary>
    private void SliceGameObject()
    {
        //SliceListener.IsSlicing = false;
        Collider[] objectsToBeSliced = Physics.OverlapBox(transform.position, new Vector3(1, 0.1f, 0.1f), transform.rotation, m_sliceMask);
        foreach (Collider objectToBeSliced in objectsToBeSliced)
        {
            ///slice onli fruit
            if (objectToBeSliced.tag != "Bomb")
            {
                SetMaterial(objectToBeSliced);

                SlicedHull slicedObject = SliceObject(objectToBeSliced.gameObject, m_materialAfterSlice);

                GameObject upperHullGameobject = slicedObject.CreateUpperHull(objectToBeSliced.gameObject, m_materialAfterSlice);
                GameObject lowerHullGameobject = slicedObject.CreateLowerHull(objectToBeSliced.gameObject, m_materialAfterSlice);

                Destroy(objectToBeSliced.gameObject);

                upperHullGameobject.transform.position = objectToBeSliced.transform.position;
                lowerHullGameobject.transform.position = objectToBeSliced.transform.position;

                MakeItPhysical(upperHullGameobject);
                MakeItPhysical(lowerHullGameobject);

                upperHullGameobject.GetComponent<Rigidbody>().AddForce(50f, 50f, 50f);
                lowerHullGameobject.GetComponent<Rigidbody>().AddForce(50f, 50f, -50f);

                OnSliceVibrate?.Invoke(tag, .5f, .5f);
                OnSliceMakeSound?.Invoke(objectToBeSliced.gameObject.layer, tag);
            }
            else//the bbom is jus des droy and we instantiate explosion 
            {
                GameObject explosion = Instantiate(m_explosion);
                explosion.transform.position = objectToBeSliced.transform.position;
                explosion.GetComponent<ParticleSystem>().Play();
                Destroy(objectToBeSliced.gameObject);
                OnSliceVibrate?.Invoke(tag, 1f, 1f);
            }
            OnSliceUpdateScore?.Invoke(objectToBeSliced.gameObject.tag);

        }
    }

    /// <summary>
    /// set the corect cut material for each fruit depend on tag 
    /// </summary>
    /// <param name="objectToBeSliced"></param>
    private void SetMaterial(Collider objectToBeSliced)
    {
        if (objectToBeSliced.tag == "apple")
            m_materialAfterSlice = m_materialsAfterSlice[0];
        else if (objectToBeSliced.tag == "avocado")
            m_materialAfterSlice = m_materialsAfterSlice[1];
        else if (objectToBeSliced.tag == "cherries")
            m_materialAfterSlice = m_materialsAfterSlice[2];
        else if (objectToBeSliced.tag == "lemon")
            m_materialAfterSlice = m_materialsAfterSlice[3];
        else if (objectToBeSliced.tag == "peach")
            m_materialAfterSlice = m_materialsAfterSlice[4];
        else if (objectToBeSliced.tag == "peanut")
            m_materialAfterSlice = m_materialsAfterSlice[5];
        else if (objectToBeSliced.tag == "pear")
            m_materialAfterSlice = m_materialsAfterSlice[6];
        else if (objectToBeSliced.tag == "strawberry")
            m_materialAfterSlice = m_materialsAfterSlice[7];
        else if (objectToBeSliced.tag == "watermelon")
            m_materialAfterSlice = m_materialsAfterSlice[8];
    }

    /// <summary>
    /// add some propertys to the new go created
    /// </summary>
    /// <param name="obj"></param>
    private void MakeItPhysical(GameObject obj)
    {
        obj.AddComponent<MeshCollider>().convex = true;
        obj.AddComponent<Rigidbody>();
        obj.layer = LayerMask.NameToLayer("Outlined");
        Destroy(obj, 1.5f);
    }

    /// <summary>
    /// Slice method
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="crossSectionMaterial"></param>
    /// <returns></returns>
    private SlicedHull SliceObject(GameObject obj, Material crossSectionMaterial = null)
    {
        return obj.Slice(transform.position, transform.up, crossSectionMaterial);
    }

    /// <summary>
    /// notify the end of slice 
    /// </summary>
    private void ResetSlice()
    {
        SliceListener.IsSlicing = false;
    }

}