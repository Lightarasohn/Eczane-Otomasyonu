const GetRaporDetay = async (raporId) => {
  
    const requestOptions = {
    method: "GET",
    headers: {
      "Content-Type": "application/json",
    },
  };

  return await fetch(`http://localhost:5169/api/rapor-satis/${raporId}`, requestOptions)
    .then(result => result.json())
    .then(data => {return data})
    .catch((e) => {console.error(e);return null;});
};

export default GetRaporDetay;
