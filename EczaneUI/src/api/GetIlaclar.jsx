const GetIlaclar = async () => {

    var requestOptions = {
        method: "GET"
    }

    return await fetch("http://localhost:5169/api/ilac", requestOptions)
    .then((result) => result.json())
    .then((data) => {return data})
    .catch((e) => {console.log(e); return []});
}

export default GetIlaclar;