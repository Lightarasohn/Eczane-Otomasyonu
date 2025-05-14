const GetSatislar = async () => {

    const requestOptions = {
        method: "GET",
        headers: {
            "Content-Type": "application/json"
        }
    }

    return await fetch("http://localhost:5169/api/satis", requestOptions)
    .then(result => result.json())
    .then(data => {return data})
    .catch(e => {console.log(e); return []});
}

export default GetSatislar;