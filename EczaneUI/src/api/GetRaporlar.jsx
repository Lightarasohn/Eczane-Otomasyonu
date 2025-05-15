const GetRaporlar = async () =>{

    const requestOptions= {
        method: "GET",
        headers: {
            "Content-Type": "application/json"
        },
    }

    return await fetch("http://localhost:5169/api/rapor", requestOptions)
    .then(result => result.json())
    .then(data => {console.log("Request cevabı:"+ data);return data})
    .catch(e => {console.log(e); return []})
}

export default GetRaporlar;