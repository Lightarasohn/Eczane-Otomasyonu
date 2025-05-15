const DeleteILac = async (ilacId) => {

    var requestOptions = {
        method: "DELETE",
    }

    return await fetch(`http://localhost:5169/api/ilac/${ilacId}`, requestOptions)
    .then((result) => result.json())
    .then((data) => {return data})
    .catch((e) => {console.log(e)});
}

export default DeleteILac;