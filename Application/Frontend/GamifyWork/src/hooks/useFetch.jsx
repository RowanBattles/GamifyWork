import { useState, useEffect } from "react";

const useFetch = (fetchFunction, dataMessage) => {
  const [data, setData] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setErrorMessage] = useState(null);

  useEffect(() => {
    async function fetchData() {
      try {
        const data = await fetchFunction();
        setData(data);
        setLoading(false);
      } catch (err) {
        if (err.response && err.response.data) {
          const { errorCode, message } = err.response.data;
          setErrorMessage(`Error ${errorCode}: ${message}`);
        } else {
          setErrorMessage(`Error: Couldn't fetch ${dataMessage}, no response`);
        }
        setLoading(false);
      }
    }

    fetchData();
  }, [fetchFunction]);

  return { data, loading, error };
};

export default useFetch;
