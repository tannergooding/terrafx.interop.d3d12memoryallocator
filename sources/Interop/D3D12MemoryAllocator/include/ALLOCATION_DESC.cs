// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using static TerraFX.Interop.D3D12_HEAP_TYPE;
using static TerraFX.Interop.D3D12_HEAP_FLAGS;

namespace TerraFX.Interop
{
    /// <summary>Parameters of created <see cref="Allocation"/> object. To be used with <see cref="Allocator.CreateResource"/>.</summary>
    public unsafe struct ALLOCATION_DESC
    {
        /// <summary>Flags.</summary>
        public ALLOCATION_FLAGS Flags;

        /// <summary>
        /// The type of memory heap where the new allocation should be placed.
        /// <para>It must be one of: <see cref="D3D12_HEAP_TYPE_DEFAULT"/>, <see cref="D3D12_HEAP_TYPE_UPLOAD"/>, <see cref="D3D12_HEAP_TYPE_READBACK"/>.</para>
        /// <para>When <c>ALLOCATION_DESC.CustomPool != null</c> this member is ignored.</para>
        /// </summary>
        public D3D12_HEAP_TYPE HeapType;

        /// <summary>
        /// Additional heap flags to be used when allocating memory.
        /// <para>In most cases it can be 0.</para>
        /// <para>
        /// - If you use <see cref="Allocator.CreateResource"/>, you don't need to care.
        /// Necessary flag <see cref="D3D12_HEAP_FLAG_ALLOW_ONLY_BUFFERS"/>, <see cref="D3D12_HEAP_FLAG_ALLOW_ONLY_NON_RT_DS_TEXTURES"/>, or <see cref="D3D12_HEAP_FLAG_ALLOW_ONLY_RT_DS_TEXTURES"/> is added automatically.
        /// </para>
        /// <para>
        /// - If you use <see cref="Allocator.AllocateMemory"/>, you should specify one of those `ALLOW_ONLY` flags.
        /// Except when you validate that <see cref="Allocator.GetD3D12Options"/> <c>ResourceHeapTier == D3D12_RESOURCE_HEAP_TIER_1</c> - then you can leave it 0.
        /// </para>
        /// <para>
        /// - You can specify additional flags if needed. Then the memory will always be allocated as separate block using <see cref="ID3D12Device.CreateCommittedResource"/> or <see cref="ID3D12Device.CreateHeap"/>, not as part of an existing larget block.
        /// </para>
        /// <para>When <see cref="ALLOCATION_DESC"/> <c>CustomPool != null</c> this member is ignored.</para>
        /// </summary>
        public D3D12_HEAP_FLAGS ExtraHeapFlags;

        /// <summary>
        /// Custom pool to place the new resource in. Optional.
        /// <para>When not <see langword="null"/>, the resource will be created inside specified custom pool. It will then never be created as committed.</para>
        /// </summary>
        public Pool* CustomPool;
    }
}
