import { useState, useEffect } from "react";

const useFetch = (fetchFunction) => {
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
        setErrorMessage("Couldn't fetch data");
        setLoading(false);
      }
    }

    fetchData();
  }, [fetchFunction]);

  return { data, loading, error };
};

export default useFetch;
