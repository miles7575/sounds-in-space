﻿//-----------------------------------------------------------------------
// <copyright file="SoundIcons.cs" company="Google">
//
// Copyright 2019 Google Inc. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// </copyright>
//-----------------------------------------------------------------------
using UnityEngine;

namespace SIS {

    public class SoundIcons : MonoBehaviour {
        MeshRenderer[] meshRends = null;
        public int Count { get { return meshRends == null ? 0 : meshRends.Length; } }
        int curIndex = 0;

        MaterialPropertyBlock propBlock;

        void Awake() {
            meshRends = GetComponentsInChildren<MeshRenderer>();
            propBlock = new MaterialPropertyBlock();
        }

        // Start is called before the first frame update
        void Start() {
            SetSoundIconWithIndex(curIndex);
        }

        public void SetSoundIconColour(Color col) {
            for (int i = 0; i < meshRends.Length; i++) {
                meshRends[i].GetPropertyBlock(propBlock);
                propBlock.SetColor("_Color", col);
                meshRends[i].SetPropertyBlock(propBlock);
            }
        }

        public void SetSoundIconWithIndex(int index) {
            curIndex = index;
            if (meshRends == null) { return; }
            for (int i = 0; i < meshRends.Length; i++) {
                meshRends[i].transform.parent.gameObject.SetActive(index == i);
            }
        }

        // Update is called once per frame
        void Update() {
            transform.Rotate(Mathf.Sin(0.618f * Time.time), Mathf.Sin(Time.time), Mathf.Sin(0.309f * Time.time));
        }
    }
}