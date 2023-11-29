import { renderHook } from "@testing-library/react-hooks";
import useFetch from "../../src/hooks/useFetch";

const mockFetchFunction = async () => {
  return [1, 2, 3];
};

test("useFetch hook fetches data correctly", async () => {
  const { result, waitForNextUpdate } = renderHook(() =>
    useFetch(mockFetchFunction)
  );

  expect(result.current.loading).toBe(true);

  await waitForNextUpdate();

  expect(result.current.loading).toBe(false);
  expect(result.current.data).toEqual([1, 2, 3]);
  expect(result.current.errorHeader).toBe(null);
  expect(result.current.errorBody).toBe(null);
});

test("useFetch hook handles fetch error", async () => {
  const errorFetchFunction = async () => {
    setErrorHeader();
    setErrorBody();
  };

  const { result, waitForNextUpdate } = renderHook(() =>
    useFetch(errorFetchFunction, "data")
  );

  await waitForNextUpdate();

  expect(result.current.loading).toBe(false);
  expect(result.current.data).toEqual([]);
  expect(result.current.errorHeader).toEqual("Unexpected error");
  expect(result.current.errorBody).toEqual("Couldn't fetch data.");
});
