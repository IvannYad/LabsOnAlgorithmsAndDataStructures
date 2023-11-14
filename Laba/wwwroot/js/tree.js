function DrawTree(arr) {
    let targetFn = treeVisualizer(
        { target: "targetDiv" }
    )
    targetFn.drawData(
        [{
            data: arr
        }]
    )

}


