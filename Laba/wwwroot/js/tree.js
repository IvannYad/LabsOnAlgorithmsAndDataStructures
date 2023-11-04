function DrawTree(arr) {
    let targetFn = treeVisualizer(
        { target: "targetDiv" }
    )
    targetFn.drawData(
        [{
            data: "[1,-5,15,-9,-4,10,17,null,-6,null,0,null,14, 12, 22, 34, null]"
        }]
    )

}

