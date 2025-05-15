const AddIlac = async (ilac) => {
    const requestOptions = {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(ilac)
    };

    return await fetch("http://localhost:5169/api/ilac", requestOptions)
    .then((result) => {return result.json()})
    .catch((e) => {console.log(e)});
}

export default AddIlac;