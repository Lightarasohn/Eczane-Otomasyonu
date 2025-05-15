const GetSatisDetay = async (satisId) => {

    const requestOptions = {
        method: "GET",
        headers: {
            "Content-Type": "application/json"
        }
    }

    return await fetch(`http://localhost:5169/api/satis-ilac/${satisId}`, requestOptions)
    .then(result => result.json())
    .then(data => {return data})
    .catch(e => {console.log(e); return null})
}

export default GetSatisDetay;