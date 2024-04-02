
const LoadEstate = async (term) => {

    const response = await fetch('https://localhost:44380/api/RealEstate')
                            .then(r => r.json())
                            .then(r => {

                                return r;

                            })

    return response.data;
  

}

export default LoadEstate;