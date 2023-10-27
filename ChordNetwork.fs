type ChordNode = {
    Key: int
    // Add other necessary fields
}

type FingerTable = {
    // Define the structure of the finger table
}

let nodes: ChordNode list = // Initialize with your network nodes


// Implement the key look up function:

let rec findSuccessor key (nodes: ChordNode list) =
    match nodes with
    | [] -> // Handle the case when the network is empty (no nodes)
        failwith "Network is empty."
    | [node] -> // Handle the case when there's only one node in the network
        node
    | _ ->
        // Sort the nodes by their keys
        let sortedNodes = List.sortBy (fun node -> node.Key) nodes

        // Find the first node whose key is greater than or equal to the given key
        let successor = List.find (fun node -> node.Key >= key) sortedNodes

        // If the successor is not found, use the first node as the successor (wrap around)
        if successor.Key <> key then
            List.head sortedNodes
        else
            successor



let keyToLookup = 10 // Replace with the key you want to look up

let responsibleNode = findSuccessor keyToLookup nodes

printfn "Key %d is managed by Node %d" keyToLookup responsibleNode.Key
