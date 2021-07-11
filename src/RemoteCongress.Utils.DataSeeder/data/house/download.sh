for i in {1..208}
do
    id=$(printf "%03d" $i)
    wget "https://clerk.house.gov/evs/2021/roll$id.xml"
done
